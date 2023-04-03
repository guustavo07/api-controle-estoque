using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

    public EstabelecimentoController(ApplicationDbContext context)
    {
        dbcontext = context;
    }

        [HttpGet]
        public IActionResult Get()
        {
            var estabelecimentos = dbcontext.Estabelecimentos.ToList();
            return Ok(estabelecimentos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estabelecimento = dbcontext.Estabelecimentos.Find(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            return Ok(estabelecimento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estabelecimento estabelecimento)
        {
            if (estabelecimento == null)
            {
                return BadRequest();
            }
            dbcontext.Estabelecimentos.Add(estabelecimento);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = estabelecimento.Id }, estabelecimento);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estabelecimento estabelecimento)
        {
            if (estabelecimento == null || estabelecimento.Id != id)
            {
                return BadRequest();
            }
            var estabelecimentoExistente = dbcontext.Estabelecimentos.Find(id);
            if (estabelecimentoExistente == null)
            {
                return NotFound();
            }
            estabelecimentoExistente.Nome = estabelecimento.Nome;
            estabelecimentoExistente.Endereco = estabelecimento.Endereco;
            estabelecimentoExistente.Estado = estabelecimento.Estado;
            estabelecimentoExistente.Num_Telefone = estabelecimento.Num_Telefone;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estabelecimento = dbcontext.Estabelecimentos.Find(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            dbcontext.Estabelecimentos.Remove(estabelecimento);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}

