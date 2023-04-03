namespace APIChurrascaria.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueId { get; set; }
        public List<EntradaProduto> EntradaProdutos { get; set; } = new List<EntradaProduto>();

    }
}
