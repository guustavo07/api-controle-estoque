namespace APIChurrascaria.DTO
{
    public class FornecedorDTO : EntidadeDTOBase
    {
        public string? Nome { get; set; }
        public int CNPJ { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Num_Telefone { get; set; }
    }
}
