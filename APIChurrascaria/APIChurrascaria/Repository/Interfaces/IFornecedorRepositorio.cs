using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    public interface IFornecedorRepositorio
    {
        Task<List<Fornecedor>> GetAllFornecedor();
        Task<Fornecedor> GetFornecedor(int id);
        Task<Fornecedor> AddFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor, int id);
        Task<bool> DeleteFornecedor(int id);
    }
}
