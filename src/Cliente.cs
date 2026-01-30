using System.Collections.Concurrent;

namespace ConsoleApp
{
    public sealed class Cliente(string nome, string email, string cpf)
    {
        public string Nome { get; } = nome;
                
        public string Email { get; } = email;
                
        public string Cpf { get; } = cpf;

        public ConcurrentBag<string> Erros { get; } = [];

        public bool ContemErros => !Erros.IsEmpty;
    }
}
