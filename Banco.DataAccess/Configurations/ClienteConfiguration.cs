using Banco.Core.Entities.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banco.DataAccess.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(m => m.IdCliente);
            builder.Property(m => m.Nombres).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Genero).IsRequired();
            builder.Property(m => m.Edad).IsRequired();
            builder.Property(m => m.Identificacion).IsRequired().HasMaxLength(15);
            builder.Property(m => m.Direccion).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Telefono).IsRequired().HasMaxLength(15);
            builder.Property(m => m.Contrasena).IsRequired().HasMaxLength(16);
            builder.Property(m => m.Estado).IsRequired();
            builder.ToTable("tbl_cliente");
        }
    }
}
