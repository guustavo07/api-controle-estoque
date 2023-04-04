using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Endereco)
                .HasColumnType("varchar(255)");
            builder.Property(p => p.Email)
                .HasColumnType("varchar(255)");
            builder.HasMany(pai => pai.EntradaProdutos)
                .WithOne(filho => filho.Fornecedor)
                .HasForeignKey(filho => filho.FornecedorId);
            builder.HasMany(pai => pai.ProdutoFornecedor)
                .WithOne(filho => filho.Fornecedor)
                .HasForeignKey(filho => filho.FornecedorId);
        }
    }
}
