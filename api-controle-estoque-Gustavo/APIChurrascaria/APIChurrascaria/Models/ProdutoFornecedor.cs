using System.Security.Principal;

namespace APIChurrascaria.Models
{
    public class ProdutoFornecedor
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
