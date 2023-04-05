using APIChurrascaria.Enum;

namespace APIChurrascaria.DTO
{
    public class PedidoDTO : EntidadeDTOBase
    {
        public double Valor_Total { get; set; }
        public StatusPedido Status { get; set; }
        public int ClienteId { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}
