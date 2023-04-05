using APIChurrascaria.DTO;
using APIChurrascaria.Models;
using AutoMapper;

namespace APIChurrascaria.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<EntradaProduto, EntradaDTO>().ReverseMap();
            CreateMap<Estabelecimento, EstabelecimentoDTO>().ReverseMap();
            CreateMap<Estoque, EstoqueDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
