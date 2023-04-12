using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Data.Mappings
{
    public class EntradaProdutoMap : IEntityTypeConfiguration<EntradaProduto>
    {
        public void Configure(EntityTypeBuilder<EntradaProduto> builder)
        {
            builder.Property(p => p.DtValidade)
                .HasColumnType("datetime");
            builder.Property(p => p.Num_Documento)
                .HasColumnType("integer");

        }
    }
}

