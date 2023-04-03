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
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(p => p.Endereco)
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.Property(p => p.Email)
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.HasMany(pai => pai.EntradaProdutos)
                .WithOne(filho => filho.Fornecedor)
                .HasForeignKey(filho => filho.FornecedorId);
        }
    }
}
