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
    [Route("api/Estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IMapper _mapper;
        public EstoqueController(IClienteRepositorio estoqueRepositorio, IMapper mapper)
        {
            estoqueRepositorio = estoqueRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstoqueDTO>>> Get()
        {
            List<Estoque> estoques = await _estoqueRepositorio.GetAllItens();
            return Ok(_mapper.Map<EstoqueDTO>(estoques));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueDTO>> Get(int id)
        {
            Estoque estoque = await _estoqueRepositorio.GetEstoque(id);
            return Ok(_mapper.Map<EstoqueDTO>(estoque));
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueDTO>> Post([FromBody] EstoqueDTO estoqueModel)
        {
            Estoque estoque = await _estoqueRepositorio.AddEstoque(_mapper.Map<Estoque>(estoqueModel));
            return Ok(_mapper.Map<EstoqueDTO>(estoque));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EstoqueDTO>> Put([FromBody] Estoque estoqueModel, int id)
        {
            estoqueModel.Id = id;

            Estoque estoque = await _estoqueRepositorio.UpdateEstoque(_mapper.Map<Estoque>(estoqueModel), id);
            return Ok(_mapper.Map<EstoqueDTO>(estoque));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _estoqueRepositorio.DeleteEstoque(id);
            return apagado;
        }
    }
}