using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public FornecedorController(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var fornecedores = dbcontext.Fornecedores.ToList();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fornecedor = dbcontext.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest();
            }
            dbcontext.Fornecedores.Add(fornecedor);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null || fornecedor.Id != id)
            {
                return BadRequest();
            }
            var fornecedorExistente = dbcontext.Fornecedores.Find(id);
            if (fornecedorExistente == null)
            {
                return NotFound();
            }
            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.CNPJ = fornecedor.CNPJ;
            fornecedorExistente.Endereco = fornecedor.Endereco;
            fornecedorExistente.Email = fornecedor.Email;
            fornecedorExistente.Num_Telefone = fornecedor.Num_Telefone;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fornecedor = dbcontext.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            dbcontext.Fornecedores.Remove(fornecedor);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
