using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces.Repositories;

namespace Banco.DataAccess.Repositories
{
    public class MovimientosRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientosRepository(BancoDbContext context)
            : base(context)
        { }

        private BancoDbContext BancoDbContext
        {
            get { return Context as BancoDbContext; }
        }
    }
}
