using APIChurrascaria.Enum;
using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(p => p.Valor_Total)
                .HasColumnType("double");
            builder.Property(p => p.Status)
                .HasColumnType("integer");
            builder.Property(p => p.Valor_Total)
                .HasColumnType("double");
            builder.HasMany(pai => pai.PedidoProduto)
                .WithOne(filho => filho.Pedido)
                .HasForeignKey(filho => filho.PedidoId);
        }
    }
}
