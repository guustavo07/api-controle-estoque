using APIChurrascaria.Models;

namespace APIChurrascaria.Repository
{
    public class PedidoRepositorio
    {
        public static List<Pedido> pedidos { get; set; } = new List<Pedido>();
        public static void AddPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
        }
        public static Pedido GetPedidos(int id)
        {
            return pedidos.FirstOrDefault(p => p.Id == id);
        }
    }
}
