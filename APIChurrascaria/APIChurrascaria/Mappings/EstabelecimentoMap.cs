using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class EstabelecimentoMap : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Endereco)
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Estado)
                .HasColumnType("varchar(255)");
            builder.HasMany(pai => pai.Pedido)
                .WithOne(filho => filho.Estabelecimento)
                .HasForeignKey(filho => filho.EstabelecimentoId);

        }
    }
}
