using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public EstoqueRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Estoque> AddEstoque(Estoque estoque)
        {
            await _dbContext.AddAsync(estoque);
            await _dbContext.SaveChangesAsync();

            return estoque;
        }

        public async Task<bool> DeleteEstoque(int id)
        {
            Estoque estoque = await GetEstoque(id);

            if (estoque == null)
            {
                return false;
            }

            _dbContext.Remove(estoque);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Estoque>> GetAllItens()
        {
            return await _dbContext.Estoques.ToListAsync();
        }

        public async Task<Estoque> GetEstoque(int id)
        {
            return await _dbContext.Estoques.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Estoque> UpdateEstoque(Estoque estoque, int id)
        {
            Estoque estoquePorId = await GetEstoque(id);

            if (estoquePorId == null)
            {
                throw new Exception($"O Estoque para o ID: {id}, não foi encontrado");
            }

            estoquePorId.Quantidade = estoque.Quantidade;
            estoquePorId.DtValidade = estoque.DtValidade;
            _dbContext.Estoques.Update(estoquePorId);
            await _dbContext.SaveChangesAsync();

            return estoquePorId;
        }
    }
}
