using Banco.Core.Interfaces.Repositories;

namespace Banco.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IMovimientoRepository Movimientos { get; }
        ICuentaRepository Cuentas { get; }

        Task<int> CommitAsync();
    }
}
