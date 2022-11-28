using LibraryApp.DAL.DbContexts;
using LibraryApp.DAL.Entities;
using LibraryApp.Repositories.Interfaces;

namespace LibraryApp.Repositories.Concretes;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(LibraryContext dbContext) : base(dbContext)
    {
    }
}