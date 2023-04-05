using APIChurrascaria.DTO;
using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/Produto")]
    [ApiController]
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
            List<Produto> produtos = await _produtoRepositorio.GetAllProdutos();
            return Ok(_mapper.Map<List<ProdutoDTO>>(produtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            Produto produto = await _produtoRepositorio.GetProduto(id);
            return Ok(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoModel)
        {
            Produto produto = await _produtoRepositorio.AddProduto(_mapper.Map<Produto>(produtoModel));
            return Ok(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Put([FromBody] ProdutoDTO produtoModel, int id)
        {
            produtoModel.Id = id;

            Produto produto = await _produtoRepositorio.UpdateProduto(_mapper.Map<Produto>(produtoModel), id);
            return Ok(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _produtoRepositorio.DeleteProduto(id);
            return apagado;
        }
    }
}
