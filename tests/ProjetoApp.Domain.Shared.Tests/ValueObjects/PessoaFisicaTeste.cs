using ProjetoApp.Domain.Shared.ValueObjects;
using System;
using Xunit;

namespace ProjetoApp.Domain.Shared.Tests.ValueObjects
{
    public class PessoaFisicaTeste
    {
        public PessoaFisica pessoafisica;

        public PessoaFisicaTeste()
        {
            pessoafisica = new PessoaFisica("", "", DateTime.Now, "", "", "", "", "", "", "", "", "");
        }

        [Fact]
        public void PessoaFisica_NomeDeveSerPreenchido_True()
        {
            // Act
            var result = pessoafisica.NomeDeveSerPreenchido("Pedro Bruno Rodrigues Lourenço");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_NomeDeveSerPreenchido_False()
        {
            // Act
            var result = pessoafisica.NomeDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PessoaFisica_NomeDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = pessoafisica.NomeDeveTerTamanhoLimite("Pedro Bruno", 200);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_NomeDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = pessoafisica.NomeDeveTerTamanhoLimite("Pedro Bruno", 5);
            // Assert
            Assert.False(result);
        }




        [Fact]
        public void PessoaFisica_TelefoneDeveSerPreenchido_True()
        {
            // Act
            var result = pessoafisica.TelefoneDeveSerPreenchido("999999999999");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_TelefoneDeveSerPreenchido_False()
        {
            // Act
            var result = pessoafisica.TelefoneDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PessoaFisica_TelefoneDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = pessoafisica.TelefoneDeveTerTamanhoLimite("9999-99999");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_TelefoneDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = pessoafisica.TelefoneDeveTerTamanhoLimite("22");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void PessoaFisica_EstadoCivilDeveSerValido_True()
        {
            // Act
            var result1 = pessoafisica.EstadoCivilDeveSerValido("C");
            var result2 = pessoafisica.EstadoCivilDeveSerValido("S");
            var result3 = pessoafisica.EstadoCivilDeveSerValido("D");
            var result4 = pessoafisica.EstadoCivilDeveSerValido("O");
            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
        }

        [Fact]
        public void PessoaFisica_EstadoCivilDeveSerValido_False()
        {
            // Act
            var result = pessoafisica.EstadoCivilDeveSerValido("X");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void PessoaFisica_GeneroDeveSerValido_True()
        {
            // Act
            var result1 = pessoafisica.GeneroDeveSerValido("M");
            var result2 = pessoafisica.GeneroDeveSerValido("F");
            var result3 = pessoafisica.GeneroDeveSerValido("I");
            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void PessoaFisica_GeneroDeveSerValido_False()
        {
            // Act
            var result1 = pessoafisica.GeneroDeveSerValido("X");
            // Assert
            Assert.False(result1);
        }


        [Fact]
        public void PessoaFisica_PessoaDeveTerUmaIdadeLimite_True()
        {
            // Act
            pessoafisica = new PessoaFisica("", "", DateTime.Now.AddYears(-21), "", "", "", "", "", "", "", "", "");
            var result = pessoafisica.PessoaDeveTerUmaIdadeLimite(20);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_PessoaDeveTerUmaIdadeLimite_False()
        {
            // Act
            pessoafisica = new PessoaFisica("", "", DateTime.Now.AddYears(-19), "", "", "", "", "", "", "", "", "");
            var result = pessoafisica.PessoaDeveTerUmaIdadeLimite(20);
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void PessoaFisica_CPFDeveSerPreenchido_True()
        {
            // Act
            var result = pessoafisica.CPFDeveSerPreenchido("338651203187");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_CPFDeveSerPreenchido_False()
        {
            // Act
            var result = pessoafisica.CPFDeveSerPreenchido("");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PessoaFisica_CPFDeveTerUmTamanhoLimite_True()
        {
            // Act
            var result = pessoafisica.CPFDeveTerTamanhoLimite("38651203187");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_CPFDeveTerUmTamanhoLimite_False()
        {
            // Act
            var result = pessoafisica.CPFDeveTerTamanhoLimite("1187");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PessoaFisica_CPFDeveSerValido_True()
        {
            // Act
            var result = pessoafisica.CPFDeveSerValido("38651203187");
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PessoaFisica_CPFDeveSerValido_False()
        {
            // Act
            var result = pessoafisica.CPFDeveSerValido("38651203186");
            // Assert
            Assert.False(result);
        }


    }
}
