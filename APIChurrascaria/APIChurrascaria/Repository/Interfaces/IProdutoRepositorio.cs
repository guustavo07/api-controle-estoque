using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> GetAllProdutos();
        Task<Produto> GetProdutos(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto, int id);
        Task<bool> DeleteProduto(int id);
    }
}
