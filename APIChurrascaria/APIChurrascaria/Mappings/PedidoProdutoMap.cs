using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrascaria.Mappings
{
    public class PedidoProdutoMap : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.HasKey(pp => pp.Id);
        }
    }
}
