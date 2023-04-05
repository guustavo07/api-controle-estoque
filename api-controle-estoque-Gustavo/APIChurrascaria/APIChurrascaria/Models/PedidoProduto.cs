namespace APIChurrascaria.Models
{
    public class PedidoProduto
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
