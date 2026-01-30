using ConsoleApp;

namespace TestProject
{
    public class ValidadorDeClientesTests
    {
        [Fact]
        public void DeveObterOsErrosDosClientesInvalidos()
        {
            //Arrange
            var cliente1 = new Cliente(
                nome: "Alice",                // Valid: MinLength 2
                email: "invalid-email",       // Invalid: Not a valid email
                cpf: "123"                    // Invalid: Not 11 characters
            );

            var cliente2 = new Cliente(
                nome: "",                     // Invalid: MinLength 2
                email: "unknown@mail.com",    // Valid: An email address
                cpf: "12345670901"            // Valid: 11 characters
            );

            var cliente3 = new Cliente(
                nome: "X",                    // Invalid: MinLength 2
                email: "test.com",            // Invalid: Not a valid email
                cpf: "12345678901234"         // Invalid: More than 11 characters
            );

            var cliente4 = new Cliente(
                nome: "Bob",                  // Valid: MinLength 2
                email: "unknown@mail.com",    // Valid: An email address
                cpf: "12345670901"            // Valid: 11 characters
            );

            //Act
            var clientes = new List<Cliente> { cliente1, cliente2, cliente3, cliente4 };
            var invalidos = new ValidadorDeClientes().ValidarClientes(clientes.AsReadOnly());

            //Assert
            Assert.Equal(3, invalidos.Count);
            Assert.DoesNotContain(invalidos, c => c.Nome == "Bob");

            Assert.Equal(2, invalidos[0].Erros.Count);
            Assert.Contains("Email inválido", invalidos[0].Erros);
            Assert.Contains("CPF inválido", invalidos[0].Erros);

            Assert.Single(invalidos[1].Erros);
            Assert.Contains("Nome inválido", invalidos[1].Erros);

            Assert.Equal(3, invalidos[2].Erros.Count);
            Assert.Contains("Nome inválido", invalidos[2].Erros);
            Assert.Contains("Email inválido", invalidos[2].Erros);
            Assert.Contains("CPF inválido", invalidos[2].Erros);
        }
    }
}
