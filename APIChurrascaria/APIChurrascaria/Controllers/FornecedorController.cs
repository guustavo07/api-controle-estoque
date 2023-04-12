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
    [Route("api/Fornecedor")]
    [ApiController]
    [Authorize]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IMapper _mapper;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio, IMapper mapper)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FornecedorDTO>>> GetAll()
        {
            try
            {
                List<Fornecedor> fornecedores = await _fornecedorRepositorio.GetAllFornecedor();
                return Ok(_mapper.Map<List<FornecedorDTO>>(fornecedores));
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
        public async Task<ActionResult<FornecedorDTO>> Get(int id)
        {
            try
            {
                Fornecedor fornecedor = await _fornecedorRepositorio.GetFornecedor(id);

                if (fornecedor == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
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
        public async Task<ActionResult<FornecedorDTO>> Post([FromBody] FornecedorDTO fornecedorModel)
        {
            try
            {
                Fornecedor fornecedor = await _fornecedorRepositorio.AddFornecedor(_mapper.Map<Fornecedor>(fornecedorModel));
                return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
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
        public async Task<ActionResult<FornecedorDTO>> Put([FromBody] FornecedorDTO fornecedorModel, int id)
        {
            try
            {
                fornecedorModel.Id = id;

                Fornecedor fornecedor = await _fornecedorRepositorio.UpdateFornecedor(_mapper.Map<Fornecedor>(fornecedorModel), id);

                if (fornecedor == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
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
                bool apagado = await _fornecedorRepositorio.DeleteFornecedor(id);

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
