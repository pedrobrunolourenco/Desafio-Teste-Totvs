using ProjetoApp.Domain.Shared.ValueObjects;
using Xunit;

namespace ProjetoApp.Domain.Shared.Tests.ValueObjects
{
    public class EnderecoTeste
    {
        public Endereco endereco;

        public EnderecoTeste()
        {
            endereco = new Endereco("", "", "", "", "");
        }

        [Fact]
        public void Endereco_LogradouroDeveSerPreenchido_True()
        {
            // Act
            var result = endereco.LogradouroDeveSerPreenchido("Av Princesa Isabel");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_LogradouroDeveSerPreenchido_False()
        {
            // Act
            var result = endereco.LogradouroDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_LogradouroDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = endereco.LogradouroDeveTerTamanhoLimite("Av Princesa Isabel",200);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_LogradouroDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = endereco.LogradouroDeveTerTamanhoLimite("Av Princesa Isabel", 5);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_CidadeDeveSerPreenchida_True()
        {
            // Act
            var result = endereco.CidadeDeveSerPreenchida("Rio De Janerio");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_CidadeDeveSerPreenchida_False()
        {
            // Act
            var result = endereco.CidadeDeveSerPreenchida("");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Endereco_CidadeDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = endereco.CidadeDeveTerTamanhoLimite("Rio de Janeiro", 50);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_CidadeDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = endereco.CidadeDeveTerTamanhoLimite("Rio de Janeiro", 5);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_BairroDeveSerPreenchido_True()
        {
            // Act
            var result = endereco.BairroDeveSerPreenchido("Copa");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_BairroDeveSerPreenchido_False()
        {
            // Act
            var result = endereco.BairroDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Endereco_BairroDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = endereco.BairroDeveTerTamanhoLimite("Copacabana", 50);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_BairroDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = endereco.BairroDeveTerTamanhoLimite("Copacabana", 5);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_UFDeveSerPreenchida_True()
        {
            // Act
            var result = endereco.UFDeveSerPreenchida("RJ");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_UFDeveSerPreenchida_False()
        {
            // Act
            var result = endereco.UFDeveSerPreenchida("");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Endereco_UFDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = endereco.UFDeveTerTamanhoLimite("RJ");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_UFDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = endereco.UFDeveTerTamanhoLimite("RJJ");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_ValidarUF_True()
        {
            // Act
            var result = endereco.ValidarUF("SP");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_ValidarUF_False()
        {
            // Act
            var result = endereco.ValidarUF("JJ");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Endereco_CEPDeveSerPreenchido_True()
        {
            // Act
            var result = endereco.CEPDeveSerPreenchido("99999999");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Endereco_CEPDeveSerPreenchido_False()
        {
            // Act
            var result = endereco.CEPDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Endereco_CEPDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = endereco.CEPDeveTerTamanhoLimite("99999999");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EnderecO_CEPDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = endereco.CEPDeveTerTamanhoLimite("99");
            // Assert
            Assert.False(result);
        }












































    }
}
