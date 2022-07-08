using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces.Repositories;

namespace Banco.DataAccess.Repositories
{
    public class CuentasRepository : Repository<Cuenta>, ICuentaRepository
    {
        public CuentasRepository(BancoDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Cuenta>> GetAllCuentasAsync()
        {
            return from cu in BancoDbContext.Cuentas
                   select new Cuenta
                   {
                       NumeroCuenta = cu.NumeroCuenta,
                       Estado = cu.Estado,
                       SaldoInicial = cu.SaldoInicial,
                       TipoCuenta = cu.TipoCuenta,
                       IdCliente = cu.IdCliente,
                       Cliente = new Cliente { IdCliente = cu.Cliente.IdCliente, Nombres = cu.Cliente.Nombres }
                   };
        }
        private BancoDbContext BancoDbContext
        {
            get { return Context as BancoDbContext; }
        }
    }
}
