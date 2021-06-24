using Xunit;
using System;
using ProjetoApp.Domain.Vaga.Entidades;
using System.Linq;

namespace ProjetoApp.Domain.Tests.Vaga.Entidades
{
    public class VagasTeste
    {

        public Vagas VagaValida;

        public VagasTeste()
        {
            VagaValida = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

        }



        [Fact]
        public void Vaga_CamposObrigatoriosDevemSerInformados_True()
        {
            // Act
            var resultado = VagaValida.EstaConsistente();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Vaga_EmpresaContratanteDeveSerInformada_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());
        }

        [Fact]
        public void Vaga_EmpresaContratanteDeveTerUmTamanhoLimiteDe100Caracteres_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "".PadLeft(101, 'x'),
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());
        }


        [Fact]
        public void Vaga_LocacaoDeveSerInformado_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());
        }

        [Fact]
        public void Vaga_LocacaoDeveTerUmTamanhoLimiteDe100Caracteres_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "".PadLeft(101, 'x'),
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());

        }

        [Fact]
        public void Vaga_ValidarStatusDaVaga_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());

        }

        [Fact]
        public void Vaga_ValidarStatusDaVaga_True()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "F",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado1 = vagas.EstaConsistente();

            // arrange
            vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado2 = vagas.EstaConsistente();


            // Assert
            Assert.True(resultado1 && resultado2);
        }

        [Fact]
        public void Vaga_CargoDeveSerInformado_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());

        }

        [Fact]
        public void Vaga_CargoDeveTerUmTamanhoLimiteDe100Caracteres_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "".PadLeft(101, 'x'),
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());
        }

        [Fact]
        public void Vaga_DescricaoVagaDeveTerUmTamanhoMinimoEMaximo_Ok()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "x".PadLeft(31, 'x'),
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.True(resultado);
            Assert.True(!vagas.ListaErros.Any());
        }

        [Fact]
        public void Vaga_DescricaoVagaDeveTerUmTamanhoMinimo_False()
        {
            // arrange
            var vagas1 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga".PadLeft(20, 'x'),
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado1 = vagas1.EstaConsistente();

            Assert.False(resultado1);
            Assert.True(vagas1.ListaErros.Any());
        }

        [Fact]
        public void Vaga_DescricaoVagaDeveTerUmTamanhoMaximo_False()
        {
            // arrange
            var vagas1 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "".PadLeft(4001, 'x'),
                                  false,
                                  "M",
                                  "",
                                  0M);

            // Act
            var resultado1 = vagas1.EstaConsistente();

            Assert.False(resultado1);
            Assert.True(vagas1.ListaErros.Any());

        }

        [Fact]
        public void Vaga_ObservacaoDeveTerUmTamanhoMaximoDe200Caracteres_False()
        {
            // arrange
            var vagas1 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "".PadLeft(4001, 'x'),
                                  false,
                                  "M", 
                                  "".PadLeft(201, 'x'),
                                  0M);

            // Act
            var resultado1 = vagas1.EstaConsistente();

            Assert.False(resultado1);
            Assert.True(vagas1.ListaErros.Any());
        }

        [Fact]
        public void Vaga_ValidarGenero_False()
        {
            // arrange
            var vagas = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "X",
                                  "",
                                  0M);

            // Act
            var resultado = vagas.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(vagas.ListaErros.Any());

        }

        [Fact]
        public void Vaga_ValidarGenero_True()
        {
            // arrange
            var vagas1 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "F",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "M",
                                  "",
                                  0M);

            var vagas2 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "F",
                                  "",
                                  0M);

            var vagas3 = new Vagas(0,
                                  "EmpresaContratante",
                                  "Locacao",
                                  DateTime.Now,
                                  "A",
                                  "Cargo",
                                  "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                                  false,
                                  "I",
                                  "",
                                  0M);



            // Act
            var resultado1 = vagas1.EstaConsistente();
            var resultado2 = vagas2.EstaConsistente();
            var resultado3 = vagas3.EstaConsistente();


            // Assert
            Assert.True(resultado1 && resultado2 && resultado3);

        }


    }


}
