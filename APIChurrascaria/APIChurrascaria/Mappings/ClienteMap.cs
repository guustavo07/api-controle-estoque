using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.HasMany(pai => pai.Pedido)
                .WithOne(filho => filho.Cliente)
                .HasForeignKey(filho => filho.ClienteId);
        }
    }
}
