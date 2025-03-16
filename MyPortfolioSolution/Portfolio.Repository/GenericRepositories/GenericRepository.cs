using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Portfolio.Repositories.GenericRepositories
{
    public class GenericRepository<T>(PortfolioDbContext context) : IGenericRepository<T> where T : class
    {
        protected PortfolioDbContext Context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

        public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
        public async ValueTask<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void UpdateAsync(T entity) => _dbSet.Update(entity);

        public void DeleteAsync(T entity) => _dbSet.Remove(entity);
    }
}
