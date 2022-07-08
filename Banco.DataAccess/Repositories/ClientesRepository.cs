using Banco.Core.Entities.DAO;
using Banco.Core.Interfaces.Repositories;

namespace Banco.DataAccess.Repositories
{
    public class ClientesRepository : Repository<Cliente>, IClienteRepository
    {
        public ClientesRepository(BancoDbContext context)
            : base(context)
        { }

        private BancoDbContext BancoDbContext
        {
            get { return Context as BancoDbContext; }
        }
    }
}
