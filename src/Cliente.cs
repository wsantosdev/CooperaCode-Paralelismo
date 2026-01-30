namespace ConsoleApp
{
    public sealed class Cliente(string nome, string email, string cpf)
    {
        public string Nome { get; init; } = nome;
                
        public string Email { get; init; } = email;
                
        public string Cpf { get; init; } = cpf;

        public List<string> Erros { get; private init; } = new List<string>(3);
    }
}
