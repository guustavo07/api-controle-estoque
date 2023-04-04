namespace APIChurrascaria.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Num_Telefone { get; set; }

        public List<EntradaProduto> EntradaProdutos { get; set; } = new List<EntradaProduto>();
        public List<ProdutoFornecedor> ProdutoFornecedor { get; set; } = new List<ProdutoFornecedor>();

    }
}
