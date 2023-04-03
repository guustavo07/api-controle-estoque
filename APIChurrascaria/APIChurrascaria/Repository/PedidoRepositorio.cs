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
        public static List<Pedido> GetAllPedidos()
        {
            return pedidos.ToList();
        }

        public static Pedido GetPedido(int id)
        {
            return pedidos.FirstOrDefault(p => p.Id == id);
        }
        public static Pedido UpdatePedido(Pedido pedido, int id)
        {
            var pedidoSalvo = PedidoRepositorio.GetPedido(id);
            pedidoSalvo.Valor_Total = pedido.Valor_Total;
            pedidoSalvo.Status = pedido.Status;
            return pedidoSalvo;
        }
        public static bool DeletePedido(int id)
        {
            Pedido pedidoPorId = PedidoRepositorio.GetPedido(id);
            
            if (pedidoPorId != null)
            {
                throw new Exception($"Pedido de ID: {id}, não foi encontrado!");
            }
            pedidos.Remove(pedidoPorId);
            return true;
        }
    }
}
