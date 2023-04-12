using System.Net;
using APIChurrascaria.BLL.Interfaces;
using APIChurrascaria.DTO;
using APIChurrascaria.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/Pedido")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoRepositorio pedidoRepositorio, IMapper mapper)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> GetAll()
        {
            try
            {
                List<Pedido> pedidos = await _pedidoRepositorio.GetAllPedidos();
                return Ok(_mapper.Map<List<PedidoDTO>>(pedidos));
            }
            catch (Exception ex)
            {
                // Logging do erro
                Console.WriteLine(ex);

                // Retorna uma resposta de erro com o status code apropriado
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> Get(int id)
        {
            try
            {
                Pedido pedido = await _pedidoRepositorio.GetPedido(id);

                if (pedido == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<PedidoDTO>(pedido));
            }
            catch (Exception ex)
            {
                // Logging do erro
                Console.WriteLine(ex);

                // Retorna uma resposta de erro com o status code apropriado
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> Post([FromBody] PedidoDTO pedidoModel)
        {
            try
            {
                Pedido pedido = await _pedidoRepositorio.AddPedido(_mapper.Map<Pedido>(pedidoModel));
                return Ok(_mapper.Map<PedidoDTO>(pedido));
            }
            catch (Exception ex)
            {
                // Logging do erro
                Console.WriteLine(ex);

                // Retorna uma resposta de erro com o status code apropriado
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDTO>> Put([FromBody] PedidoDTO pedidoModel, int id)
        {
            try
            {
                pedidoModel.Id = id;

                Pedido pedido = await _pedidoRepositorio.UpdatePedido(_mapper.Map<Pedido>(pedidoModel), id);

                if (pedido == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<PedidoDTO>(pedido));
            }
            catch (Exception ex)
            {
                // Logging do erro
                Console.WriteLine(ex);

                // Retorna uma resposta de erro com o status code apropriado
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool apagado = await _pedidoRepositorio.DeletePedido(id);

                if (apagado == false)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                // Logging do erro
                Console.WriteLine(ex);
                // Retorna uma resposta de erro com o status code apropriado
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
