using APIChurrascaria.DTO;
using APIChurrascaria.Models;
using AutoMapper;

namespace APIChurrascaria.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
