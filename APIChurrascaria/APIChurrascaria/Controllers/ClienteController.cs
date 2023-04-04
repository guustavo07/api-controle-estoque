using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private readonly ApplicationDbContext dbcontext;

        public ClienteController(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = dbcontext.Clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = dbcontext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Nome))
            {
                return BadRequest();
            }
            dbcontext.Clientes.Add(cliente);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id != id)
            {
                return BadRequest();
            }
            var clienteExistente = dbcontext.Clientes.Find(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }
            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Num_Mesa = cliente.Num_Mesa;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = dbcontext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            dbcontext.Clientes.Remove(cliente);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
