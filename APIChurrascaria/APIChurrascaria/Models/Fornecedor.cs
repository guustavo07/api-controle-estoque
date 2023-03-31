namespace APIChurrascaria.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Num_Telefone { get; set; }
    }
}
