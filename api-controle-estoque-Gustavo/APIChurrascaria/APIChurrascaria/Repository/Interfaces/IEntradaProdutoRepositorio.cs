using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    public interface IEntradaProdutoRepositorio
    {
        Task<List<EntradaProduto>> GetAll();
        Task<EntradaProduto> GetById(int id);
        Task<EntradaProduto> AddEntrada(EntradaProduto entradaProduto);
        Task<EntradaProduto> UpdateEntrada(EntradaProduto entradaProduto, int id);
        Task<bool> DeleteEntrada(int id);
    }
}
