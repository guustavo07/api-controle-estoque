using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    //criação dos metodos para implementar no repositório
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> GetAllCliente();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente, int id);
        Task<bool> DeleteCliente(int id);
    }
}
