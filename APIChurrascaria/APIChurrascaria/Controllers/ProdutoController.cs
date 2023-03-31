using APIChurrascaria.Infra.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ApplicationDbContext dbcontext;

        public ProdutoController(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = dbcontext.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = dbcontext.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }
            dbcontext.Produtos.Add(produto);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (produto == null || produto.Id != id)
            {
                return BadRequest();
            }
            var produtoExistente = dbcontext.Produtos.Find(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Valor = produto.Valor;
            produtoExistente.Quantidade = produto.Quantidade;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = dbcontext.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            dbcontext.Produtos.Remove(produto);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
