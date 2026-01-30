using System.Runtime.InteropServices;

namespace ConsoleApp
{
    public class ValidadorDeClientes
    {
        public static List<Cliente> ValidarClientes(List<Cliente> clientes)
        {
            var clientesInvalidos = new List<Cliente>(clientes.Count);

            foreach(var cliente in clientes)
            {
                if (string.IsNullOrEmpty(cliente.Nome) || cliente.Nome.Length < 2)
                    cliente.Erros.Add("Nome inválido");
                if (string.IsNullOrEmpty(cliente.Email) || !cliente.Email.Contains('@'))
                    cliente.Erros.Add("Email inválido");
                if (string.IsNullOrEmpty(cliente.Cpf) || cliente.Cpf.Length != 11)
                    cliente.Erros.Add("CPF inválido");
                
                if (cliente.Erros.Count > 0)
                    clientesInvalidos.Add(cliente);
            }
            
            return clientesInvalidos;
        }
    }
}
