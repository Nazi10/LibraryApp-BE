using LibraryApp.Models;

namespace LibraryApp.Services.Interfaces;

public interface IBookService
{
    public Task Add(AddBookDTO bookDto); 
    
    public IEnumerable<BookDTO> GetAll();
    public IEnumerable<BookDTO> GetByAuthorId(Guid id);
    
    public BookDTO? GetById(Guid id);
    
    public Task Update(AddBookDTO entity);
    
    public void Delete(Guid id);
    
}