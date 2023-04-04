namespace APIChurrascaria.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        //public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        
        public int Quantidade { get; set; }
        
        public DateTime DtValidade { get; set; }
        public List<Produto> Produto { get; set; } = new List<Produto>();


    }
}
