
using ConsoleApp;
using System.Diagnostics;

var clientes = new List<Cliente>(10000);

// 5000 valid clients
for (int i = 0; i < 5000; i++)
{
    clientes.Add(new Cliente(
        nome: $"Cliente Válido {i}",
        email: $"cliente{i}@example.com",
        cpf: "12345678901"
    ));
}

// 5000 invalid clients (with missing/invalid fields)
for (int i = 0; i < 5000; i++)
{
    var invalidType = i % 3;
    clientes.Add(invalidType switch
    {
        0 => new Cliente(
            nome: "A",  // Too short (MinLength = 2)
            email: $"cliente{i}@example.com",
            cpf: "12345678901"
        ),
        1 => new Cliente(
            nome: $"Cliente Inválido {i}",
            email: "email-invalido",  // Invalid email format
            cpf: "12345678901"
        ),
        _ => new Cliente(
            nome: $"Cliente Inválido {i}",
            email: $"cliente{i}@example.com",
            cpf: "123"  // Invalid CPF length
        )
    });
}

var clientesInvalidos = ValidadorDeClientes.ValidarClientes(clientes);

Console.WriteLine($"Total de clientes: {clientes.Count}");
Console.WriteLine($"Clientes inválidos: {clientesInvalidos.Count}");
