using APIChurrascaria.Models;

namespace APIChurrascaria.Repository
{
    public class ClienteRepositorio
    {
        public static List<Cliente> clientes { get; set; } = new List<Cliente>();
        public static void AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public static Cliente GetCliente(int id)
        {
            return clientes.FirstOrDefault(p => p.Id == id);
        }
        public static List<Cliente> GetClienteList()
        {
            return clientes.ToList();
        }
        public static Cliente UpdateCliente(Cliente cliente, int id)
        {
            var clienteSalvo = ClienteRepositorio.GetCliente(id);
            clienteSalvo.Nome = cliente.Nome;
            clienteSalvo.Num_Mesa = cliente.Num_Mesa;
            return clienteSalvo;
        }

        public static bool DeleteCliente(int id)
        {
            Cliente clientePorId = GetCliente(id);
            if (clientePorId == null)
            {
                throw new Exception($"Usuario do ID: {id} não foi encontrado!");
            }
            clientes.Remove(clientePorId);
            return true;
        }
    }
}
