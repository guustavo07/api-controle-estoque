using APIChurrascaria.DTO;
using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/Pedido")]
    [ApiController]
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
            List<Pedido> pedidos = await _pedidoRepositorio.GetAllPedidos();
            return Ok(_mapper.Map<PedidoDTO>(pedidos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> Get(int id)
        {
            Pedido pedido = await _pedidoRepositorio.GetPedido(id);
            return Ok(_mapper.Map<PedidoDTO>(pedido));
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> Post([FromBody] PedidoDTO pedidoModel)
        {
            Pedido pedido = await _pedidoRepositorio.AddPedido(_mapper.Map<Pedido>(pedidoModel));
            return Ok(_mapper.Map<PedidoDTO>(pedido));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDTO>> Put([FromBody] PedidoDTO pedidoModel, int id)
        {
            pedidoModel.Id = id;

            Pedido pedido = await _pedidoRepositorio.UpdatePedido(_mapper.Map<Pedido>(pedidoModel), id);
            return Ok(_mapper.Map<PedidoDTO>(pedido));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _pedidoRepositorio.DeletePedido(id);
            return apagado;
        }
    }
}
