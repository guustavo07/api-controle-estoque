namespace APIChurrascaria.DTO
{
    public class ProdutoDTO : EntidadeDTOBase
    {
        public string? Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueId { get; set; }
    }
}
