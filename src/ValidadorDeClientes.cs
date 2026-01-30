using System.Collections.ObjectModel;

namespace ConsoleApp
{
    public class ValidadorDeClientes
    {
        // Não injetado para simplificar o exemplo
        private readonly ReadOnlyCollection<IRegraValidacao> _regrasValidacao = [ new RegraNomeValido(), 
                                                                                  new RegraEmailValido(), 
                                                                                  new RegraCpfValido() ];

        public ReadOnlyCollection<Cliente> ValidarClientes(ReadOnlyCollection<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                //Desacopla as regras de validação do processo de validação
                foreach (var regra in _regrasValidacao)
                    regra.Validar(cliente);
            }

            return [.. clientes.Where(c => c.ContemErros)];
        }
    }
}