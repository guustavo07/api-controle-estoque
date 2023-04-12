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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntradaProdutoController : ControllerBase
    {
        private readonly IEntradaProdutoRepositorio _EntradaProdutoRepositorio;
        private readonly IMapper _mapper;
        public EntradaProdutoController(IEntradaProdutoRepositorio EntradaProdutoRepositorio, IMapper mapper)
        {
            _EntradaProdutoRepositorio = EntradaProdutoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntradaDTO>>> GetAll()
        {
            try
            {
                List<EntradaProduto> entradas = await _EntradaProdutoRepositorio.GetAll();

                if (entradas == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<List<EntradaDTO>>(entradas));
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
        public async Task<ActionResult<EntradaDTO>> Get(int id)
        {
            try
            {
                EntradaProduto entrada = await _EntradaProdutoRepositorio.GetById(id);

                if (entrada == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<EntradaDTO>(entrada));
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
        public async Task<ActionResult<EntradaDTO>> Post([FromBody] EntradaDTO entradaModel)
        {
            try
            {
                EntradaProduto entrada = await _EntradaProdutoRepositorio.AddEntrada(_mapper.Map<EntradaProduto>(entradaModel));
                return Ok(_mapper.Map<EntradaDTO>(entrada));
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
        public async Task<ActionResult<EntradaDTO>> Put([FromBody] EntradaDTO entradaModel, int id)
        {
            try
            {
                entradaModel.Id = id;

                EntradaProduto entrada = await _EntradaProdutoRepositorio.UpdateEntrada(_mapper.Map<EntradaProduto>(entradaModel), id);

                if (entrada == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<EntradaDTO>(entrada));
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
                bool apagado = await _EntradaProdutoRepositorio.DeleteEntrada(id);

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
