using APIChurrascaria.Models;

namespace APIChurrascaria.DTO
{
    public class EntradaDTO : EntidadeDTOBase
    {
        public int Quantidade { get; set; }
        public DateTime DtValidade { get; set; }
        public int Num_Documento { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
    }
}
