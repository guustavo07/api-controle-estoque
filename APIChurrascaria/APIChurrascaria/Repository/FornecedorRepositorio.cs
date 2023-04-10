using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public FornecedorRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Fornecedor> AddFornecedor(Fornecedor fornecedor)
        {
            await _dbContext.Fornecedores.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> DeleteFornecedor(int id)
        {
            Fornecedor fornecedorPorId = await GetFornecedor(id);

            if (fornecedorPorId == null)
            {
                return false;
            }

            _dbContext.Fornecedores.Remove(fornecedorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Fornecedor>> GetAllFornecedor()
        {
            return await _dbContext.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> GetFornecedor(int id)
        {
            return await _dbContext.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor, int id)
        {
            Fornecedor fornecedorPorId = await GetFornecedor(id);

            if (fornecedorPorId == null)
            {
                throw new Exception($"Fornecedor para o ID: {id}, não foi encontrado");
            }

            fornecedorPorId.Nome = fornecedor.Nome;
            fornecedorPorId.Email = fornecedor.Email;
            fornecedorPorId.Endereco = fornecedor.Endereco;
            fornecedorPorId.CNPJ = fornecedor.CNPJ;
            fornecedorPorId.Num_Telefone = fornecedor.Num_Telefone;

            _dbContext.Fornecedores.Update(fornecedorPorId);
            await _dbContext.SaveChangesAsync();

            return fornecedorPorId;
        }
    }
}
