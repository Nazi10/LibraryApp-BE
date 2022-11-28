using LibraryApp.DAL.Entities;

namespace LibraryApp.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    public User GetByEmail(string email);
    public IEnumerable<User> GetAuthors();
    // public IEnumerable<User> GetBooks();
}