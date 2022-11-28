using LibraryApp.DAL.Entities;

namespace LibraryApp.Repositories.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    void UpdateBookCategories(Book book);
}