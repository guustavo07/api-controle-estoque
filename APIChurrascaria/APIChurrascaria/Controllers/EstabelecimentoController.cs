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
    [Route("api/Estabelecimento")]
    [ApiController]
    [Authorize]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepositorio _estabelecimentoRepositorio;
        private readonly IMapper _mapper;
        public EstabelecimentoController(IEstabelecimentoRepositorio estabelecimentoRepositorio, IMapper mapper)
        {
            _estabelecimentoRepositorio = estabelecimentoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstabelecimentoDTO>>> GetAll()
        {
            try
            {
                List<Estabelecimento> estabelecimentos = await _estabelecimentoRepositorio.GetAll();
                return Ok(_mapper.Map<List<EstabelecimentoDTO>>(estabelecimentos));
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
        public async Task<ActionResult<EstabelecimentoDTO>> Get(int id)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepositorio.GetEstabelecimento(id);

                if (estabelecimento == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
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
        public async Task<ActionResult<EstabelecimentoDTO>> Post([FromBody] EstabelecimentoDTO estabelecimentoModel)
        {
            try
            {
                Estabelecimento estabelecimento = await _estabelecimentoRepositorio.AddEstabelecimento(_mapper.Map<Estabelecimento>(estabelecimentoModel));
                return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
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
        public async Task<ActionResult<EstabelecimentoDTO>> Put([FromBody] EstabelecimentoDTO estabelecimentoModel, int id)
        {
            try
            {
                estabelecimentoModel.Id = id;
                Estabelecimento estabelecimento = await _estabelecimentoRepositorio.UpdateEstabelecimento(_mapper.Map<Estabelecimento>(estabelecimentoModel), id);
                if (estabelecimento == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool apagado = await _estabelecimentoRepositorio.DeleteEstabelecimento(id);

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

