using Banco.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Banco.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context) => Context = context;
        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();
        public ValueTask<TEntity> GetByIdAsync(int id) => Context.Set<TEntity>().FindAsync(id);
        public ValueTask<TEntity> GetByIdAsync(string id) => Context.Set<TEntity>().FindAsync(id);
        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        public void Update(TEntity entity) => Context.Set<TEntity>().UpdateRange(entity);
        public void UpdateRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().UpdateRange(entities);
    }
}
