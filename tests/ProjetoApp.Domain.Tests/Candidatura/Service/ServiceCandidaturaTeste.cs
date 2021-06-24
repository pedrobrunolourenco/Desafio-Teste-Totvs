using Moq;
using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Intefaces;
using ProjetoApp.Domain.Candidatura.Services;
using System.Linq;
using Xunit;

namespace ProjetoApp.Domain.Tests.Candidatura.Service
{
    public class ServiceCandidaturaTeste
    {
        public CandidaturasInclusaoDTO CandidaturaValidaInclusao;
        public CandidaturasInclusaoDTO CandidaturaInValidaInclusao;

        public ServiceCandidaturaTeste()
        {
            CandidaturaValidaInclusao = new CandidaturasInclusaoDTO
            {
                IdCandidato = 1,
                IdVaga = 10
            };

            CandidaturaInValidaInclusao = new CandidaturasInclusaoDTO
            {
                IdCandidato = 0,
                IdVaga = 0
            };

        }

        [Fact(DisplayName = "Adicionar Candidatura com Sucesso")]
        public void ServiceCandidatura_Adicionar_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidaturas>();
            // Act
            var service = new ServiceCandidaturas(vagaRepo.Object);
            // assert
            Assert.True(service.IncluirCandidatura(CandidaturaValidaInclusao).Consistente == true);
        }

        [Fact(DisplayName = "Adicionar Candidatura com Falha")]
        public void ServiceCandidatura_Adicionar_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidaturas>();
            // Act
            var service = new ServiceCandidaturas(vagaRepo.Object);
            Assert.True(service.IncluirCandidatura(CandidaturaInValidaInclusao).ListaErros.Any());
        }


        [Fact(DisplayName = "Excluir Candidatura com Sucesso")]
        public void ServiceCandidatura_Excluir_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidaturas>();
            var service = new ServiceCandidaturas(vagaRepo.Object);
            // Act
            Assert.True(service.ExcluirCandidatura(10) != null);
        }

        [Fact(DisplayName = "Excluir Candidato com Falha")]
        public void ServiceCandidatura_Excluir_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidaturas>();
            var service = new ServiceCandidaturas(vagaRepo.Object);
            // Act
            Assert.True(service.ExcluirCandidatura(10).ListaErros.Any());
        }





    }
}
