using Banco.Core.Interfaces;
using Banco.Core.Interfaces.Repositories;
using Banco.DataAccess;
using Banco.DataAccess.Repositories;
using System.Threading.Tasks;

namespace MyMusic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BancoDbContext _context;
        
        private ClientesRepository _clientesRepository;
        private CuentasRepository _cuentasRepository;
        private MovimientosRepository _movimientosRepository;

        public UnitOfWork(BancoDbContext context)
        {
            this._context = context;
        }

        public IClienteRepository Clientes => _clientesRepository = _clientesRepository ?? new ClientesRepository(_context);
        public ICuentaRepository Cuentas => _cuentasRepository = _cuentasRepository ?? new CuentasRepository(_context);
        public IMovimientoRepository Movimientos => _movimientosRepository = _movimientosRepository ?? new MovimientosRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}