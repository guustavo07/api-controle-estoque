namespace APIChurrascaria.DTO
{
    public class EstoqueDTO : EntidadeDTOBase
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtValidade { get; set; }
    }
}
