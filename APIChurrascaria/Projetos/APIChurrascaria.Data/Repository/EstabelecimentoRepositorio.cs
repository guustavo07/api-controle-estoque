using APIChurrascaria.BLL.Interfaces;
using APIChurrascaria.Data.Context;
using APIChurrascaria.Models;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class EstabelecimentoRepositorio : IEstabelecimentoRepositorio
    {
        //variavel somente leitura para ler o banco de dados
        private readonly ApplicationDbContext _dbContext;

        public EstabelecimentoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Estabelecimento> AddEstabelecimento(Estabelecimento estabelecimento)
        {
            await _dbContext.Estabelecimentos.AddAsync(estabelecimento);
            await _dbContext.SaveChangesAsync();

            return estabelecimento;
        }

        public async Task<bool> DeleteEstabelecimento(int id)
        {
            Estabelecimento estabelecimentoPorId = await GetEstabelecimento(id);

            if (estabelecimentoPorId == null)
            {
                return false;
            }

            _dbContext.Estabelecimentos.Remove(estabelecimentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Estabelecimento> GetEstabelecimento(int id)
        {
            return await _dbContext.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Estabelecimento>> GetAll()
        {
            return await _dbContext.Estabelecimentos.ToListAsync();
        }

        public async Task<Estabelecimento> UpdateEstabelecimento(Estabelecimento estabelecimento, int id)
        {
            Estabelecimento estabelecimentoPorId = await GetEstabelecimento(id);

            if (estabelecimentoPorId == null)
            {
                throw new Exception($"O estabelecimento {id}, não foi encontrado!");
            }

            estabelecimentoPorId.Nome = estabelecimento.Nome;
            estabelecimentoPorId.Num_Telefone = estabelecimento.Num_Telefone;
            estabelecimentoPorId.Estado = estabelecimento.Estado;
            estabelecimentoPorId.Endereco = estabelecimento.Endereco;

            _dbContext.Estabelecimentos.Update(estabelecimentoPorId);
            await _dbContext.SaveChangesAsync();

            return estabelecimentoPorId;
        }
    }
}
