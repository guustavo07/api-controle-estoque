using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(p => p.Valor)
                .HasColumnType("double")
                .IsRequired();
            builder.HasMany(pai => pai.EntradaProdutos)
                .WithOne(filho => filho.Produto)
                .HasForeignKey(filho => filho.ProdutoId);
        }
    }
}
