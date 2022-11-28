using LibraryApp.DAL.DbContexts;
using LibraryApp.DAL.Entitites;
using LibraryApp.Repositories.Interfaces;

namespace LibraryApp.Repositories.Concretes;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(LibraryContext dbContext) : base(dbContext)
    {
    } 
}