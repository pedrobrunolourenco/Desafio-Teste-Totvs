using ProjetoApp.Domain.Candidatura.Entidades;
using System.Linq;
using Xunit;

namespace ProjetoApp.Domain.Tests.Candidatura.Entidades
{
    public class CandidaturaTeste
    {
        public Candidaturas CandidaturaValida;

        public CandidaturaTeste()
        {
            CandidaturaValida = new Candidaturas(0, 10, 20);
        }

        [Fact]
        public void Candidaturas_CamposObrigatoriosDevemSerInformados_True()
        {
            var resultado = CandidaturaValida.EstaConsistente();

            // Assert
            Assert.True(resultado);
            Assert.False(CandidaturaValida.ListaErros.Any());
        }

        [Fact]
        public void Candidaturas_IdDoCandidatoDeveSerInformado_False()
        {
            // Assert
            // assert
            var candidatura = new Candidaturas(0, 0, 10);
            // Act

            // Act
            var resultado = candidatura.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(candidatura.ListaErros.Any());

        }


        [Fact]
        public void Candidaturas_IdDaVagaDeveSerInformada_False()
        {
            // Assert
            // assert
            var candidatura = new Candidaturas(0, 10, 0);
            // Act

            // Act
            var resultado = candidatura.EstaConsistente();

            // Assert
            Assert.False(resultado);
            Assert.True(candidatura.ListaErros.Any());

        }

    }
}
