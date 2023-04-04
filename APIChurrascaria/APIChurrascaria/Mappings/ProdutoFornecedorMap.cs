using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class ProdutoFornecedorMap : IEntityTypeConfiguration<ProdutoFornecedor>
    {
        public void Configure(EntityTypeBuilder<ProdutoFornecedor> builder)
        {
            builder.HasKey(pp => pp.Id);
        }
    }
}
