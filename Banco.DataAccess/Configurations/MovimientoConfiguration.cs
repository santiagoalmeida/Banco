using Banco.Core.Entities.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banco.DataAccess.Configurations
{
    public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder
                .HasKey(m => m.IdMovimiento);

            builder
                .Property(m => m.Fecha)
                .IsRequired();

            builder
                .Property(m => m.TipoMovimiento)
                .IsRequired();

            builder
                .Property(m => m.Valor)
                .IsRequired();

            builder
                .Property(m => m.NumeroCuenta)
                .IsRequired();

            builder
                .HasOne(c => c.Cuenta)
                .WithMany(c => c.Movimientos);
        }
    }
}
