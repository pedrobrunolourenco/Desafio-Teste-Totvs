using ProjetoApp.Domain.Shared.ValueObjects;
using Xunit;

namespace ProjetoApp.Domain.Shared.Tests.ValueObjects
{
    public class EmailTeste
    {

        public Email EmailValido;
        public Email EmailInvalido;


        public EmailTeste()
        {
            EmailValido = new Email("PedroBruno@gmail.com");
            EmailInvalido = new Email("PedroGmail.com");
        }

        [Fact]
        public void Email_EmailDeveSerPreenchido_True()
        {
            // Act
            var result = EmailValido.EmailDeveSerPreenchido(EmailValido.EnderecoEmail);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Email_EmailDeveSerPreenchido_False()
        {
            // Act
            var result = EmailValido.EmailDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Email_EmailDeveSerValido_True()
        {
            // Act
            var result = EmailValido.EmailDeveSerValido(EmailValido.EnderecoEmail);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Email_EmailDeveSerValido_False()
        {
            // Act
            var result = EmailInvalido.EmailDeveSerValido(EmailInvalido.EnderecoEmail);
            // Assert
            Assert.False(result);
        }




    }
}
