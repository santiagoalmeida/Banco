using Banco.Core.Entities.DAO;
using Banco.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Banco.DataAccess
{
    public class BancoDbContext : DbContext
    {

        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new CuentaConfiguration());
            modelBuilder.ApplyConfiguration(new MovimientoConfiguration());
        }
    }
}
