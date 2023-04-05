using APIChurrascaria.Models;

namespace APIChurrascaria.Repository.Interfaces
{
    public interface IEstabelecimentoRepositorio
    {
        Task<List<Estabelecimento>> GetAll();
        Task<Estabelecimento> GetEstabelecimento(int id);
        Task<Estabelecimento> AddEstabelecimento(Estabelecimento estabelecimento);
        Task<Estabelecimento> UpdateEstabelecimento(Estabelecimento estabelecimento, int id);
        Task<bool> DeleteEstabelecimento(int id);

    }
}
