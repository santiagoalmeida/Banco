using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Requests;
using Banco.Core.Entities.Response;

namespace Banco.Core.Interfaces.Services
{
    public interface IMovimientosService : ICrudServiceBase<Movimiento>
    {
        Task<IEnumerable<ConsultaMovimientosResponse>> GetQueryMovimientosAsync(ConsultaMovimientosRequest request);
    }
}
