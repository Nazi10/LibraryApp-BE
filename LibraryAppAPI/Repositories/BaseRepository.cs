using LibraryApp.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LibraryApp.DAL.Entities;

namespace LibraryApp.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly LibraryContext _dbContext;

    protected BaseRepository(LibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> GetAll() => _dbContext.Set<T>().AsNoTracking();
    public T? GetById(Guid id) => _dbContext.Set<T>().Find(id);
    public async Task<T?> GetByIdAsync(Guid id) => await _dbContext.Set<T>().FindAsync(id);
    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression);
    public void Create(T entity) => _dbContext.Set<T>().Add(entity);
    public async Task CreateAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
    public void Update(T entity) => _dbContext.Set<T>().Update(entity);
    public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
    public void Save() => _dbContext.SaveChanges();
    public async Task SaveAsync() => await _dbContext.SaveChangesAsync(); 

}
