using APIChurrascaria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EntradaProdutoController(ApplicationDbContext dbContext)
        {
            dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entradas = dbContext.EntradaProdutos
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .ToList();

            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entrada = dbContext.EntradaProdutos
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .FirstOrDefault(e => e.Id == id);

            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EntradaProduto entradaProduto)
        {
            if (entradaProduto == null)
            {
                return BadRequest();
            }

            dbContext.EntradaProdutos.Add(entradaProduto);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = entradaProduto.Id }, entradaProduto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EntradaProduto entradaProduto)
        {
            if (entradaProduto == null || entradaProduto.Id != id)
            {
                return BadRequest();
            }

            var entradaExistente = dbContext.EntradaProdutos.Find(id);
            if (entradaExistente == null)
            {
                return NotFound();
            }

            entradaExistente.Quantidade = entradaProduto.Quantidade;
            entradaExistente.Data_Validade = entradaProduto.Data_Validade;
            entradaExistente.NumDocumento = entradaProduto.NumDocumento;
            entradaExistente.FornecedorId = entradaProduto.FornecedorId;
            entradaExistente.ProdutoId = entradaProduto.ProdutoId;

            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entrada = dbContext.EntradaProdutos.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            dbContext.EntradaProdutos.Remove(entrada);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
