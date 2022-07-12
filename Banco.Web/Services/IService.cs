using Banco.Web.Models;

namespace Banco.Web.Services
{
    public interface IServices<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int Id);
        Task PostAsync(TEntity entity);
        Task PutAsync(TEntity entity);
        Task DeleteAsync(int Id);
        Task<IEnumerable<ConsultaMovimientos>> GetReporteMovimientosAsync(ParamsConsultaMovimientos param);
    }
}
