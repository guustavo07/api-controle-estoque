namespace APIChurrascaria.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public int Num_Telefone { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
