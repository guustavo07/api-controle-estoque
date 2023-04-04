using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class EntradaProdutoRepositorio : IEntradaProdutoRepositorio
    {
        //variavel somente leitura para ler o banco de dados
        private readonly ApplicationDbContext _dbContext;

        public EntradaProdutoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntradaProduto> AddEntrada(EntradaProduto entradaProduto)
        {
            await _dbContext.EntradasProdutos.AddAsync(entradaProduto);
            await _dbContext.SaveChangesAsync();

            return entradaProduto;
        }

        public async Task<bool> DeleteEntrada(int id)
        {
            EntradaProduto entradaPorId = await GetById(id);

            if (entradaPorId == null)
            {
                throw new Exception($"A entrada com ID: {id}, não foi encontrado!");
            }

            _dbContext.EntradasProdutos.Remove(entradaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<EntradaProduto>> GetAll()
        {
            return await _dbContext.EntradasProdutos.ToListAsync();
        }

        public async Task<EntradaProduto> GetById(int id)
        {
            return await _dbContext.EntradasProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EntradaProduto> UpdateEntrada(EntradaProduto entradaProduto, int id)
        {
            EntradaProduto entradaPorId = await GetById(id);

            if (entradaPorId == null)
            {
                throw new Exception($"A entrada com ID: {id}, não foi encontrado!");
            }

            entradaPorId.Quantidade = entradaProduto.Quantidade;
            entradaPorId.DtValidade = entradaProduto.DtValidade;
            entradaPorId.Num_Documento = entradaProduto.Num_Documento;

            _dbContext.EntradasProdutos.Update(entradaPorId);
            await _dbContext.SaveChangesAsync();

            return entradaPorId;
        }
    }
}
