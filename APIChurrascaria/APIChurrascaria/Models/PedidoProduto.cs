namespace APIChurrascaria.Models
{
    public class PedidoProduto
    {
        public Pedido Pedidos { get; set; }
        public int PedidoId { get; set; }
        public Produto Produtos { get; set; }
        public int ProdutoId { get; set; }
    }
}
