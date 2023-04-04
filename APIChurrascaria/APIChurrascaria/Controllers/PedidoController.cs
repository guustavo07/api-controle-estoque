using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // GET: api/<PedidoController>
        private readonly ApplicationDbContext dbcontext;

        public PedidoController(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = dbcontext.Pedidos.ToList();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = dbcontext.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }
            dbcontext.Pedidos.Add(pedido);
            dbcontext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.Id != id)
            {
                return BadRequest();
            }
            var pedidoExistente = dbcontext.Pedidos.Find(id);
            if (pedidoExistente == null)
            {
                return NotFound();
            }

            pedidoExistente.Valor_Total = pedido.Valor_Total;
            pedidoExistente.Status = pedido.Status;
            dbcontext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = dbcontext.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }
            dbcontext.Pedidos.Remove(pedido);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
