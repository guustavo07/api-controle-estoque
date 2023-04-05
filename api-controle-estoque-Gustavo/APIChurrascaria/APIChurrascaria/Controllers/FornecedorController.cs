using APIChurrascaria.DTO;
using APIChurrascaria.Infra.Data;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChurrascaria.Controllers
{
    [Route("api/Fornecedor")]
    [ApiController]
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
            List<Fornecedor> fornecedores = await _fornecedorRepositorio.GetAllFornecedor();
            return Ok(_mapper.Map<List<FornecedorDTO>>(fornecedores));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDTO>> Get(int id)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.GetFornecedor(id);
            return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> Post([FromBody] FornecedorDTO fornecedorModel)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.AddFornecedor(_mapper.Map<Fornecedor>(fornecedorModel));
            return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FornecedorDTO>> Put([FromBody] FornecedorDTO fornecedorModel, int id)
        {
            fornecedorModel.Id = id;

            Fornecedor fornecedor = await _fornecedorRepositorio.UpdateFornecedor(_mapper.Map<Fornecedor>(fornecedorModel), id);
            return Ok(_mapper.Map<FornecedorDTO>(fornecedor));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _fornecedorRepositorio.DeleteFornecedor(id);
            return apagado;
        }
    }
}
