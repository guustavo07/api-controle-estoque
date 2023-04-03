using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
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

        public EntradaProdutoController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entradas = dbContext.EntradasProdutos
                .Include(e => e.FornecedorId)
                .Include(e => e.ProdutoId)
                .ToList();

            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entrada = dbContext.EntradasProdutos
                .Include(e => e.FornecedorId)
                .Include(e => e.ProdutoId)
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

            dbContext.EntradasProdutos.Add(entradaProduto);
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

            var entradaExistente = dbContext.EntradasProdutos.Find(id);
            if (entradaExistente == null)
            {
                return NotFound();
            }

            entradaExistente.Quantidade = entradaProduto.Quantidade;
            entradaExistente.DtValidade = entradaProduto.DtValidade;
            entradaExistente.Num_Documento = entradaProduto.Num_Documento;
            entradaExistente.FornecedorId = entradaProduto.FornecedorId;
            entradaExistente.ProdutoId = entradaProduto.ProdutoId;

            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entrada = dbContext.EntradasProdutos.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            dbContext.EntradasProdutos.Remove(entrada);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
