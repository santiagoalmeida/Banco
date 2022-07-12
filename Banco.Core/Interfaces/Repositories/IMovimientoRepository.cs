using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Response;

namespace Banco.Core.Interfaces.Repositories
{
    public interface IMovimientoRepository: IRepository<Movimiento>
    {
        Task<int> GetValorDiarioRetiro(DateTime fecha, string numeroCuenta);
        Task<int> GetSaldo(string numeroCuenta);
        Task<IEnumerable<ConsultaMovimientosResponse>> GetQueryMovimientosAsync(int idCliente, DateTime desde, DateTime hasta);
    }
}
