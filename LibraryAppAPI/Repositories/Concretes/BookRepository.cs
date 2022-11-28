using LibraryApp.DAL.DbContexts;
using LibraryApp.DAL.Entities;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repositories.Concretes;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(LibraryContext dbContext) : base(dbContext)
    {
    }

    public void UpdateBookCategories(Book book)
    {
        var existingBook = _dbContext.Book?.AsNoTracking().Include(x => x.BookCategories).FirstOrDefault(x => x.Id == book.Id);

        _dbContext.TryUpdateManyToMany(existingBook.BookCategories, book.BookCategories
            .Select(x => new BookCategory
            {
                BookId = book.Id,
                CategoryId = x.CategoryId
            }), x => x.CategoryId);
        _dbContext.SaveChanges();
        _dbContext.ChangeTracker.Clear();
    }
}