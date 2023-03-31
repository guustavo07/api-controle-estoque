using APIChurrascaria.Enum;

namespace APIChurrascaria.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public double Valor_Total { get; set; }
        public StatusPedido Status { get; set;}
    }
}
