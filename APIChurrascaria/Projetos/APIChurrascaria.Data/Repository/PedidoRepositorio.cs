using APIChurrascaria.BLL.Interfaces;
using APIChurrascaria.Data.Context;
using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Data.Repository
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        //variavel somente leitura para ler o banco de dados
        private readonly ApplicationDbContext _dbContext;

        public PedidoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            await _dbContext.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> DeletePedido(int id)
        {
            Pedido pedidoPorId = await GetPedido(id);

            if (pedidoPorId == null)
            {
                return false;
            }

            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetPedido(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pedido> UpdatePedido(Pedido pedido, int id)
        {
            Pedido pedidoPorId = await GetPedido(id);

            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido pelo ID: {id}, não foi encontrado!");
            }

            pedidoPorId.Valor_Total = pedido.Valor_Total;
            pedidoPorId.Status = pedido.Status;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoPorId;
        }
    }
}
