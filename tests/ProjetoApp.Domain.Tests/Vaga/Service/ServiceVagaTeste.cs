using Moq;
using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Intefaces;
using ProjetoApp.Domain.Vaga.Services;
using System;
using System.Linq;
using Xunit;

namespace ProjetoApp.Domain.Tests.Vaga.Service
{

    public class ServiceVagaTeste
    {
        public VagasInclusaoDTO VagaValida;
        public VagasInclusaoDTO VagaInvalida;


        public VagasAlteracaoDTO VagaValidaAltera;
        public VagasAlteracaoDTO VagaInvalidaAltera;


        public ServiceVagaTeste()
        {
            VagaValida = new VagasInclusaoDTO
            {  
                EmpresaContratante = "EmpresaContratante",
                Locacao = "Locacao",
                DataAbertura = DateTime.Now,
                Status = "A",
                Cargo = "Cargo",
                DescricaoVaga = "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                InglesFluente = false,
                Genero = "M",
                Graduacao = false,
                Observacao = "Observacao",
                Salario = 5000 
            } ;

            VagaInvalida = new VagasInclusaoDTO
            {
                EmpresaContratante = "",
                Locacao = "",
                DataAbertura = DateTime.Now,
                Status = "",
                Cargo = "",
                DescricaoVaga = "",
                InglesFluente = false,
                Genero = "",
                Graduacao = false,
                Observacao = "",
                Salario = 0
            };


            VagaValidaAltera = new VagasAlteracaoDTO
            {
                Id = 10,
                EmpresaContratante = "EmpresaContratante",
                Locacao = "Locacao",
                DataAbertura = DateTime.Now,
                Status = "A",
                Cargo = "Cargo",
                DescricaoVaga = "DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga DescricaoVaga",
                InglesFluente = false,
                Genero = "M",
                Graduacao = false,
                Observacao = "Observacao",
                Salario = 5000
            };

            VagaInvalidaAltera = new VagasAlteracaoDTO
            {
                Id = 12,
                EmpresaContratante = "",
                Locacao = "",
                DataAbertura = DateTime.Now,
                Status = "",
                Cargo = "",
                DescricaoVaga = "",
                InglesFluente = false,
                Genero = "",
                Graduacao = false,
                Observacao = "",
                Salario = 0
            };
        }


        [Fact(DisplayName = "Adicionar Vaga com Sucesso")]
        public void ServiceVagas_Adicionar_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.IncluirVaga(VagaValida).Consistente == true);
        }


        [Fact(DisplayName = "Adicionar Vaga com Falha")]
        public void ServiceVagas_Adicionar_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.IncluirVaga(VagaInvalida).Consistente == false);
            Assert.True(vagaservice.IncluirVaga(VagaInvalida).ListaErros.Any());
        }


        [Fact(DisplayName = "Alterar Vaga com Sucesso")]
        public void ServiceVagas_Alterar_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.AlterarVaga(VagaValidaAltera).Consistente == true);
        }


        [Fact(DisplayName = "Alterar Vaga com Falha")]
        public void ServiceVagas_Alterar_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.AlterarVaga(VagaInvalidaAltera).Consistente == false);
            Assert.True(vagaservice.AlterarVaga(VagaInvalidaAltera).ListaErros.Any());
        }


        [Fact(DisplayName = "Excluir Vaga com Sucesso")]
        public void ServiceVagas_Excluir_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.ExcluirVaga(10) != null);
        }


        [Fact(DisplayName = "Excluir Vaga com Falha")]
        public void ServiceVagas_Excluir_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryVagas>();
            var vagaservice = new ServiceVagas(vagaRepo.Object);
            // Act
            Assert.True(vagaservice.ExcluirVaga(10).ListaErros.Any());
        }


    }
}
