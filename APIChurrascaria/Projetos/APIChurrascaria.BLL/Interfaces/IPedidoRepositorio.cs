using APIChurrascaria.Models;

namespace APIChurrascaria.BLL.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<Pedido>> GetAllPedidos();
        Task<Pedido> GetPedido(int id);
        Task<Pedido> AddPedido(Pedido pedido);
        Task<Pedido> UpdatePedido(Pedido pedido, int id);
        Task<bool> DeletePedido(int id);

    }
}
