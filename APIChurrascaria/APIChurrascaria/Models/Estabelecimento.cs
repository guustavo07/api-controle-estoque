﻿namespace APIChurrascaria.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Num_Telefone { get; set; }
        public List<Pedido> Pedido { get; set; } = new List<Pedido>();


    }
}
