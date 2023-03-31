using System.Security.Principal;

namespace APIChurrascaria.Models
{
    public class ProdutoFornecedor
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
    }
}
