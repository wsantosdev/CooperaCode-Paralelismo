namespace ConsoleApp
{
    public interface IRegraValidacao
    {
        void Validar(Cliente cliente);
    }

    public sealed class RegraNomeValido : IRegraValidacao
    {
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome) || cliente.Nome.Length < 2)
                cliente.Erros.Add("Nome inválido");
        }
    }

    public sealed class RegraEmailValido : IRegraValidacao
    {
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains('@'))
                cliente.Erros.Add("Email inválido");
        }
    }

    public sealed class RegraCpfValido : IRegraValidacao
    {
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Cpf) || cliente.Cpf.Length != 11)
                cliente.Erros.Add("CPF inválido");
        }
    }
}
