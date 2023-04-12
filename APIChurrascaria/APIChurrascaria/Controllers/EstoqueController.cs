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
    [Route("api/Estoque")]
    [ApiController]
    [Authorize]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IMapper _mapper;
        public EstoqueController(IEstoqueRepositorio estoqueRepositorio, IMapper mapper)
        {
            _estoqueRepositorio = estoqueRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstoqueDTO>>> GetAll()
        {
            try
            {
                List<Estoque> estoques = await _estoqueRepositorio.GetAllItens();
                return Ok(_mapper.Map<List<EstoqueDTO>>(estoques));
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
        public async Task<ActionResult<EstoqueDTO>> Get(int id)
        {
            try
            {
                Estoque estoque = await _estoqueRepositorio.GetEstoque(id);

                if (estoque == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<EstoqueDTO>(estoque));
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
        public async Task<ActionResult<EstoqueDTO>> Post([FromBody] EstoqueDTO estoqueModel)
        {
            try
            {
                Estoque estoque = await _estoqueRepositorio.AddEstoque(_mapper.Map<Estoque>(estoqueModel));
                return Ok(_mapper.Map<EstoqueDTO>(estoque));
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
        public async Task<ActionResult<EstoqueDTO>> Put([FromBody] EstoqueDTO estoqueModel, int id)
        {
            try
            {
                estoqueModel.Id = id;

                Estoque estoque = await _estoqueRepositorio.UpdateEstoque(_mapper.Map<Estoque>(estoqueModel), id);

                if (estoque == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<EstoqueDTO>(estoque));
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
                bool apagado = await _estoqueRepositorio.DeleteEstoque(id);

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