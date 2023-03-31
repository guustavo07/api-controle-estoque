using APIChurrascaria.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public EstoqueController(ApplicationDbContext context)
        {
            dbcontext = context;
        }
        // GET: api/<EstoqueController>
        [HttpGet]
        public IActionResult Get()
        {
            var estoques = dbcontext.Estoques.ToList();
            return Ok(estoques);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estoque = dbcontext.Estoques.Find(id);
            if (estoque == null)
            {
                return NotFound();
            }
            return Ok(estoque);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estoque estoque)
        {
            if (estoque == null)
            {
                return BadRequest();
            }
            dbcontext.Estoques.Add(estoque);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = estoque.Id }, estoque);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estoque estoque)
        {
            if (estoque == null || estoque.Id != id)
            {
                return BadRequest();
            }
            var estoqueExistente = dbcontext.Estoques.Find(id);
            if (estoqueExistente == null)
            {
                return NotFound();
            }
            estoqueExistente.ProdutoId = estoque.ProdutoId;
            estoqueExistente.Quantidade = estoque.Quantidade;
            estoqueExistente.Data_validade = estoque.Data_validade;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estoque = dbcontext.Estoques.Find(id);
            if (estoque == null)
            {
                return NotFound();
            }
            dbcontext.Estoques.Remove(estoque);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}