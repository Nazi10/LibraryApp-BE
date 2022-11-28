using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Repositories
{
    public interface IBaseRepository<T>
    {
        public IQueryable<T> GetAll();
        public T? GetById(Guid id);
        public Task<T?> GetByIdAsync(Guid id);
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        public void Create(T entity);
        public Task CreateAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        
        // public void DeleteById(Guid id);
        public void Save();
        public Task SaveAsync();
    }
}
