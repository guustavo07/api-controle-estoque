using APIChurrascaria.Models;

namespace APIChurrascaria.BLL.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> GetAllProdutos();
        Task<Produto> GetProduto(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto, int id);
        Task<bool> DeleteProduto(int id);
    }
}
