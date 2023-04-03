using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIChurrascaria.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        //variavel somente leitura para ler o banco de dados
        private readonly ApplicationDbContext _dbContext;

        public ProdutoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            Produto produtoPorId = await GetProdutos(id);
            
            if (produtoPorId == null)
            {
                throw new Exception($"Produto com ID: {id}, não foi encontrado!");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutos(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> UpdateProduto(Produto produto, int id)
        {
            Produto produtoPorId = await GetProdutos(id);

            if (produtoPorId == null)
            {
                throw new Exception($"O Produto com ID: {id}, não foi encontrado");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Valor = produto.Valor;
            produtoPorId.Quantidade = produto.Quantidade;
            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }
    }
}
