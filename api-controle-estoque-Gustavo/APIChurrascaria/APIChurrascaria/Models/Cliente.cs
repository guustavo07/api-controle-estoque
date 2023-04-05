using System.Text.Json.Serialization;

namespace APIChurrascaria.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Num_Mesa { get; set; }

        public List<Pedido> Pedido { get; set; } = new List<Pedido>();

    }
}
