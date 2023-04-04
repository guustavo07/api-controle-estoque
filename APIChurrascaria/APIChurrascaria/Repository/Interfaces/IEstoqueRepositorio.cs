using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<Estoque> GetEstoque(int id);
        Task<List<Estoque>> GetAllItens();
        Task<Estoque> AddEstoque(Estoque estoque);
        Task<Estoque> UpdateEstoque(Estoque estoque, int id);
        Task<bool> DeleteEstoque(int id);
    }
}
