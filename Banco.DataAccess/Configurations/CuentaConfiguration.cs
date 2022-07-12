using Banco.Core.Entities.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banco.DataAccess.Configurations
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(m => m.NumeroCuenta);
            builder.Property(m => m.NumeroCuenta).HasMaxLength(8);
            builder.Property(m => m.IdCliente).IsRequired();
            builder.Property(m => m.TipoCuenta).IsRequired();
            builder.HasOne(c => c.Cliente).WithMany(c => c.Cuentas).HasForeignKey(c => c.IdCliente);
        }
    }
}
