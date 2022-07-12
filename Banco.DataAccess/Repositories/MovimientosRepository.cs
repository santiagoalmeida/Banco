using Banco.Core.Constantes;
using Banco.Core.Entities.DAO;
using Banco.Core.Entities.Response;
using Banco.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banco.DataAccess.Repositories
{
    public class MovimientosRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientosRepository(BancoDbContext context)
            : base(context)
        { }

        public async Task<int> GetValorDiarioRetiro(DateTime fecha, string numeroCuenta)
        {
            var query = from mov in BancoDbContext.Movimientos
                        where mov.NumeroCuenta == numeroCuenta &&
                        mov.Fecha.Date == fecha.Date &&
                        mov.TipoMovimiento == TipoMovimiento.Retiro
                        select mov.Valor;

            return await query.SumAsync(c => c);
        }

        public async Task<int> GetSaldo(string numeroCuenta)
        {
            var query = from mov in BancoDbContext.Movimientos
                        where mov.NumeroCuenta == numeroCuenta
                        select mov.Valor;
            return await query.SumAsync(c => c);
        }

        public async Task<IEnumerable<ConsultaMovimientosResponse>> GetQueryMovimientosAsync(int idCliente, DateTime desde, DateTime hasta)
        {
            var query = from mov in BancoDbContext.Movimientos
                        where mov.Cuenta.IdCliente == idCliente &&
                        mov.Fecha.Date >= desde.Date && mov.Fecha.Date <= hasta.Date
                        orderby mov.NumeroCuenta, mov.Fecha
                        select new ConsultaMovimientosResponse
                        {
                            Fecha = mov.Fecha,
                            Cliente = mov.Cuenta.Cliente.Nombres,
                            NumeroCuenta = mov.NumeroCuenta,
                            Tipo = mov.Cuenta.TipoCuenta,
                            SaldoInicial = mov.Cuenta.SaldoInicial,
                            Estado = mov.Cuenta.Estado,
                            Movimiento = mov.Valor
                        };
            var resp = await query.ToListAsync();

            foreach (ConsultaMovimientosResponse crm in resp)
            {
                crm.SaldoDisponible = resp.Where(mov => mov.NumeroCuenta == crm.NumeroCuenta && 
                                                 mov.Fecha <= crm.Fecha).Sum(c => c.Movimiento);
            }
            return resp;
        }

        private BancoDbContext BancoDbContext
        {
            get { return Context as BancoDbContext; }
        }
    }
}
