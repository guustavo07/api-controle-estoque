using APIChurrascaria.DTO;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIChurrascaria.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }
        
        //private readonly ApplicationDbContext dbcontext;

        //public ClienteController(ApplicationDbContext context)
        //{
        //    dbcontext = context;
        //}

        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetAll()
        {
            List<Cliente> clientes = await _clienteRepositorio.GetAllCliente();
            return Ok(_mapper.Map<List<ClienteDTO>>(clientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            Cliente cliente = await _clienteRepositorio.GetClienteById(id);
            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] ClienteDTO clienteModel)
        {
            if (clienteModel == null || string.IsNullOrEmpty(clienteModel.Nome))
            {
                return BadRequest();
            }
            Cliente cliente = await _clienteRepositorio.AddCliente(_mapper.Map<Cliente>(clienteModel));
            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put([FromBody] ClienteDTO cliente, int id)
        {
            cliente.Id = id;

            Cliente clientePorId = await _clienteRepositorio.UpdateCliente(_mapper.Map<Cliente>(cliente), id);
            return Ok(_mapper.Map<ClienteDTO>(clientePorId));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _clienteRepositorio.DeleteCliente(id);
            return apagado;
        }
    }
}
