using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Valor)
                .HasColumnType("double");
            builder.HasMany(pai => pai.EntradaProdutos)
                .WithOne(filho => filho.Produto)
                .HasForeignKey(filho => filho.ProdutoId);
            builder.HasMany(pai => pai.PedidoProduto)
                .WithOne(filho => filho.Produto)
                .HasForeignKey(filho => filho.ProdutoId);
            builder.HasMany(pai => pai.ProdutoFornecedor)
                .WithOne(filho => filho.Produto)
                .HasForeignKey(filho => filho.ProdutoId);
        }
    }
}
