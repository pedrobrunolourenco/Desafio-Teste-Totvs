using ProjetoApp.Domain.Candidato.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ProjetoApp.Domain.Tests.Candidato.Entidades
{
    public class CandidatosTeste
    {

        public Candidatos CandidatoValido;

        public CandidatosTeste()
        {
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");
        }

        [Fact]
        public void Candidatos_CamposObrigatoriosDevemSerInformados_True()
        {
            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.True(resultado);
            Assert.False(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_NomeDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_NomeDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CPFDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CPFDoCandidatoDeveTer11Caracteres_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "3865120318",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CPFDoCandidatoDeveSerValido_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203188",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_DeveTerUmaIdadeMinima_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-17),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_ValidarEstadoCivil_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "X",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_ValidarGernero_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "X",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());
        }

        [Fact]
        public void Candidatos_TelefoneDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_TelefoneDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "219676283090000",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_EmailDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_EmailDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunorl".PadRight(200, 'x') + "@gmail.com.br",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_EmailDoCandidataDeveSerValido_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobruno.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());
        }


        [Fact]
        public void Candidatos_LogradouroDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_LogradouroDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7".PadRight(201),
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_BairroDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_BairroDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana".PadRight(51),
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CidadeDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CidadeDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro".PadRight(51),
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }


        [Fact]
        public void Candidatos_CEPDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_CEPDoCandidatoDeveTer8Caracteres_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "2201101",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_UFDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "",
                                            "22011000",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_UFDoCandidatoDeveTer2Caracteres_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_UFDoCandidatoDeveSerValida_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "JJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_ProfissaoDoCandidatoDeveSerInformado_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "",
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_ProfissaoDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas".PadRight(200, 'x'),
                                            "Analista de Sistemas",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_FormacaoDoCandidatoDeveSerInformada_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor",
                                            "",
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_FormacaoDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor",
                                            "Analista de Sistemas".PadRight(200, 'x'),
                                            "G",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }


        [Fact]
        public void Candidatos_InstituicaoDoCandidatoDeveSerInformada_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor",
                                            "Analista de Sistemas",
                                            "G",
                                            "");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_InstituicaoDoCandidatoDeveTerTamanhoLimite_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "X".PadRight(101),
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor",
                                            "Analista de Sistemas",
                                            "G",
                                            "UFRG".PadRight(200, 'x'));

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());

        }

        [Fact]
        public void Candidatos_ValidarNivelDeFormacao_False()
        {
            // Assert
            CandidatoValido = new Candidatos(0,
                                            "Pedro Bruno Rodrigues Lourenço",
                                            "38651203187",
                                            DateTime.Today.AddYears(-55),
                                            "C",
                                            "M",
                                            "21967628309",
                                            "pedrobrunoRL@hotmail.com",
                                            "Av. Princesa Isabel, 7",
                                            "Copacabana",
                                            "Rio de Janeiro",
                                            "RJ",
                                            "22011011",
                                            "Desenvolvedor de Sistemas",
                                            "Analista de Sistemas",
                                            "x",
                                            "Universidade Cândido Mendes do Estado do Rio de Janeiro");

            // Act
            var resultado = CandidatoValido.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(CandidatoValido.ListaErros.Any());
        }

    }
}
