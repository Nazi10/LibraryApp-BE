using AutoMapper;
using LibraryApp.DAL.Entities;
using LibraryApp.Models;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.Concretes;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BookService(IBookRepository bookRepository,
        IMapper mapper,
        IWebHostEnvironment webHostEnvironment)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task Add(AddBookDTO bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        if (bookDto.PhotoFile != null)
        {
            book.Photo = await AddBookImage(bookDto);
        }
        foreach (var categoryId in bookDto.CategoriesIds)
        {
            BookCategory bookCategory = new()
            {
                BookId = book.Id,
                CategoryId = categoryId
            };
            book.BookCategories.Add(bookCategory);
        }
        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveAsync();
    }

    public IEnumerable<BookDTO> GetAll()
    {
        IEnumerable<Book> books = _bookRepository.GetAll().Include(x => x.Author)
            .Include(x => x.BookCategories).ThenInclude(x => x.Category);
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public IEnumerable<BookDTO> GetByAuthorId(Guid id)
    {
        IEnumerable<Book> books = _bookRepository
            .GetByCondition(x => x.AuthorId == id)
            .Include(x=> x.Author)
            .Include(x => x.BookCategories).ThenInclude(x => x.Category);
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public BookDTO? GetById(Guid id)
    {
        var book = _bookRepository.GetById(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task Update(AddBookDTO entity)
    {
        var book = _mapper.Map<Book>(entity);
        if (entity.PhotoFile != null)
        {
            book.Photo = await AddBookImage(entity);
        }
        foreach (var categoryId in entity.CategoriesIds)
        {
            BookCategory bookCategory = new()
            {
                BookId = book.Id,
                CategoryId = categoryId
            };
            book.BookCategories.Add(bookCategory);
        }
        _bookRepository.UpdateBookCategories(book);
        _bookRepository.Update(book);
        await _bookRepository.SaveAsync(); 
    }

    public void Delete(Guid id)
    {
        var book = _bookRepository.GetById(id);
        _bookRepository.Delete(book);
        _bookRepository.Save();
    }

    
    private static async Task<string> AddBookImage(AddBookDTO bookDto)
    {
        List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        var extension = Path.GetExtension(bookDto.PhotoFile.FileName);
        if (ImageExtensions.Contains(extension.ToUpperInvariant()))
        {
            using var dataStream = new MemoryStream();
            await bookDto.PhotoFile.CopyToAsync(dataStream);
            byte[] imageBytes = dataStream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
        else
        {
            throw new Exception("Image format must be in JPG, BMP or PNG");
        }
    }
    
}