using Banco.Core.Entities.DAO;

namespace Banco.Core.Interfaces.Repositories
{
    public interface ICuentaRepository : IRepository<Cuenta>
    {
        Task<IEnumerable<Cuenta>> GetAllCuentasAsync();
    }
}
