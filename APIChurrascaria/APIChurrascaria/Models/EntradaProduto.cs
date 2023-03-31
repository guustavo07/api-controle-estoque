namespace APIChurrascaria.Models
{
    public class EntradaProduto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtValidade { get; set; }
        public int Num_Documento { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
    }
}
