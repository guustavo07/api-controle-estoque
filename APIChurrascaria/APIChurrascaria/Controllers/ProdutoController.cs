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
    [Route("api/Produto")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoDTO>>> GetAll()
        {
            try
            {
                List<Produto> produtos = await _produtoRepositorio.GetAllProdutos();
                return Ok(_mapper.Map<List<ProdutoDTO>>(produtos));
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
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            try
            {
                Produto produto = await _produtoRepositorio.GetProduto(id);

                if (produto == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<ProdutoDTO>(produto));
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
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoModel)
        {
            try
            {
                Produto produto = await _produtoRepositorio.AddProduto(_mapper.Map<Produto>(produtoModel));
                return Ok(_mapper.Map<ProdutoDTO>(produto));
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
        public async Task<ActionResult<ProdutoDTO>> Put([FromBody] ProdutoDTO produtoModel, int id)
        {
            try
            {
                produtoModel.Id = id;

                Produto produto = await _produtoRepositorio.UpdateProduto(_mapper.Map<Produto>(produtoModel), id);

                if (produto == null)
                {
                    // Retorna um status code 404 (Not Found) se o recurso não for encontrado
                    return NotFound();
                }

                return Ok(_mapper.Map<ProdutoDTO>(produto));
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
                bool apagado = await _produtoRepositorio.DeleteProduto(id);

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
