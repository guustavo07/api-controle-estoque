using System.Net;
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
            try
            {
                List<Cliente> clientes = await _clienteRepositorio.GetAllCliente();
                return Ok(_mapper.Map<List<ClienteDTO>>(clientes));
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
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            try
            {
                Cliente cliente = await _clienteRepositorio.GetClienteById(id);

                if (cliente == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<ClienteDTO>(cliente));
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
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] ClienteDTO clienteModel)
        {
            try
            {
                if (clienteModel == null || string.IsNullOrEmpty(clienteModel.Nome))
                {
                    return BadRequest();
                }

                Cliente cliente = await _clienteRepositorio.AddCliente(_mapper.Map<Cliente>(clienteModel));
                return Ok(_mapper.Map<ClienteDTO>(cliente));
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
        public async Task<ActionResult<ClienteDTO>> Put([FromBody] ClienteDTO cliente, int id)
        {
            try
            {
                cliente.Id = id;

                Cliente clientePorId = await _clienteRepositorio.UpdateCliente(_mapper.Map<Cliente>(cliente), id);

                if (clientePorId == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<ClienteDTO>(clientePorId));
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
                bool apagado = await _clienteRepositorio.DeleteCliente(id);

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
