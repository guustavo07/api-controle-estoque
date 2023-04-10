using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //variavel somente leitura para ler o banco de dados
        private readonly ApplicationDbContext _dbContext;

        public ClienteRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            Cliente cliente = await GetClienteById(id);

            if(cliente == null)
            {
                return false;
            }

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> GetAllCliente()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente, int id)
        {
            Cliente clientePorId = await GetClienteById(id);

            if(clientePorId == null)
            {
                throw new Exception($"O cliente para o ID: {id}, não foi encontrado!");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Num_Mesa = cliente.Num_Mesa;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();
            return clientePorId;
        }
    }
}
