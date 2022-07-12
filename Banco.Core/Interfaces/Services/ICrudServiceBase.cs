namespace Banco.Core.Interfaces.Services
{
    public interface ICrudServiceBase<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
