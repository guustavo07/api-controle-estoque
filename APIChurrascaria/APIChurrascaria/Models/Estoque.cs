namespace APIChurrascaria.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtValidade { get; set; }
    }
}
