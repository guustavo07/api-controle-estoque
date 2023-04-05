using APIChurrascaria.Enum;

namespace APIChurrascaria.Models
{
    public class Pedido
    {

        public int Id { get; set; }
        public double Valor_Total { get; set; }
        public StatusPedido Status { get; set; }
        public int ClienteId { get; set; }
        public int EstabelecimentoId { get; set; }
        public Cliente Cliente { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public List<PedidoProduto> PedidoProduto { get; set; } = new List<PedidoProduto>();
    }
}
