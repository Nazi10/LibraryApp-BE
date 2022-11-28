using LibraryApp.DAL.DbContexts;
using LibraryApp.DAL.Entities;
using LibraryApp.Enumerations;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repositories.Concretes;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(LibraryContext dbContext) : base(dbContext)
    {
    }

    public User? GetByEmail(string email) =>
         _dbContext.User?.Where(x => x.Email.ToLower().Equals(email.ToLower())).Include(x => x.Role).FirstOrDefault();

    public IEnumerable<User> GetAuthors() =>
        _dbContext.User.Include(x => x.Role).Include(x => x.Books).Where(x => x.Role.Name.ToLower() == UserRole.Author.ToString().ToLower());
}