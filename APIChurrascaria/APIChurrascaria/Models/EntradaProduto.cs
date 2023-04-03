using System.Security.Cryptography.X509Certificates;

namespace APIChurrascaria.Models
{
    public class EntradaProduto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtValidade { get; set; }
        public int Num_Documento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
