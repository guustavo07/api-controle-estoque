using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.Property(p => p.DtValidade)
                .HasColumnType("datetime");
            builder.HasMany(pai => pai.Produto)
                .WithOne(filho => filho.Estoque)
                .HasForeignKey(filho => filho.EstoqueId);
        }
    }
}
