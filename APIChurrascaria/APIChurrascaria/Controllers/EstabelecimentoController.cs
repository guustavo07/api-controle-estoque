using APIChurrascaria.DTO;
using APIChurrascaria.Models;
using APIChurrascaria.Repository.Interfaces;
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
            List<Estabelecimento> estabelecimentos = await _estabelecimentoRepositorio.GetAll();
            return Ok(_mapper.Map<List<EstabelecimentoDTO>>(estabelecimentos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> Get(int id)
        {
            Estabelecimento estabelecimento = await _estabelecimentoRepositorio.GetEstabelecimento(id);
            return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
        }

        [HttpPost]
        public async Task<ActionResult<EstabelecimentoDTO>> Post([FromBody] EstabelecimentoDTO estabelecimentoModel)
        {
            Estabelecimento estabelecimento = await _estabelecimentoRepositorio.AddEstabelecimento(_mapper.Map<Estabelecimento>(estabelecimentoModel));
            return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> Put([FromBody] EstabelecimentoDTO estabelecimentoModel, int id)
        {
            estabelecimentoModel.Id = id;

            Estabelecimento estabelecimento = await _estabelecimentoRepositorio.UpdateEstabelecimento(_mapper.Map<Estabelecimento>(estabelecimentoModel), id);
            return Ok(_mapper.Map<EstabelecimentoDTO>(estabelecimento));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool apagado = await _estabelecimentoRepositorio.DeleteEstabelecimento(id);
            return apagado;
        }
    }
}

