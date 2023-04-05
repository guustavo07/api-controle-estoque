using APIChurrascaria.DTO;
using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            List<EntradaProduto> entradaprodutos = await _EntradaProdutoRepositorio.GetAll();
            return Ok(_mapper.Map<EntradaDTO>(entradaprodutos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaDTO>> Get(int id)
        {
            EntradaProduto entradaproduto = await _EntradaProdutoRepositorio.GetById(id);
            return Ok(_mapper.Map<EntradaDTO>(entradaproduto));
        }

        [HttpPost]
        public async Task<ActionResult<EntradaDTO>> Post([FromBody] EntradaDTO entradaModel)
        {
            EntradaProduto entradaProduto = await _EntradaProdutoRepositorio.AddEntrada(_mapper.Map<EntradaProduto>(entradaModel));
            return Ok(_mapper.Map<EntradaDTO>(entradaProduto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntradaDTO>> Put([FromBody] EntradaDTO entradaModel, int id)
        {
            entradaModel.Id = id;

            EntradaProduto entradaProduto = await _EntradaProdutoRepositorio.UpdateEntrada(_mapper.Map<EntradaProduto>(entradaModel), id);
            return Ok(_mapper.Map<EntradaDTO>(entradaProduto));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _EntradaProdutoRepositorio.DeleteEntrada(id);
            return apagado;
        }
    }
}
