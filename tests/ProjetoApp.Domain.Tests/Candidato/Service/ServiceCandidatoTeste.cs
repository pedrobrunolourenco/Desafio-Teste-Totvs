using Moq;
using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Interfaces;
using ProjetoApp.Domain.Candidato.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ProjetoApp.Domain.Tests.Candidato.Service
{
    public class ServiceCandidatoTeste
    {

        public CandidatosInclusaoDTO CandidatoValidoInclusao;
        public CandidatosInclusaoDTO CandidatoInvalidoInclusao;

        public CandidatosAlteracaoDTO CandidatoValidoAlteracao;
        public CandidatosAlteracaoDTO CandidatoInvalidoAlteracao;


        public ServiceCandidatoTeste()
        {

            CandidatoValidoInclusao = new CandidatosInclusaoDTO
            {
                Nome = "Pedro Bruno Rodrigues Lourenço",
                Cpf = "38651203187",
                DataNascimento = Convert.ToDateTime("09/04/1966"),
                EstadoCivil = "C",
                Genero = "M",
                Telefone = "21967628309",
                Email = "PedroBrunoRl@Hotmail.com",
                Logradouro = "Av. Princesa Isabel, 7",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Uf = "RJ",
                Cep = "22011011",
                Profissao = "Arquiteto de Sistemas",
                Formacao = "Analista De Sistemas",
                NivelFormacao = "G",
                Instituicao = "Universidade Federal do Rio de Janeiro"
            };

            CandidatoInvalidoInclusao = new CandidatosInclusaoDTO
            {
                Nome = "",
                Cpf = "",
                DataNascimento = Convert.ToDateTime("09/04/1966"),
                EstadoCivil = "",
                Genero = "",
                Telefone = "",
                Email = "",
                Logradouro = "",
                Bairro = "",
                Cidade = "",
                Uf = "",
                Cep = "",
                Profissao = "",
                Formacao = "",
                NivelFormacao = "",
                Instituicao = ""
            };


            CandidatoValidoAlteracao = new CandidatosAlteracaoDTO
            {
                Id = 10,
                Nome = "Pedro Bruno Rodrigues Lourenço",
                Cpf = "38651203187",
                DataNascimento = Convert.ToDateTime("09/04/1966"),
                EstadoCivil = "C",
                Genero = "M",
                Telefone = "21967628309",
                Email = "PedroBrunoRl@Hotmail.com",
                Logradouro = "Av. Princesa Isabel, 7",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Uf = "RJ",
                Cep = "22011011",
                Profissao = "Arquiteto de Sistemas",
                Formacao = "Analista de Sistemas",
                NivelFormacao = "G",
                Instituicao = "Universidade Federal do Rio de Janeiro"
            };

            CandidatoInvalidoAlteracao = new CandidatosAlteracaoDTO
            {
                Id = 10,
                Nome = "",
                Cpf = "",
                DataNascimento = Convert.ToDateTime("09/04/1966"),
                EstadoCivil = "",
                Genero = "",
                Telefone = "",
                Email = "",
                Logradouro = "",
                Bairro = "",
                Cidade = "",
                Uf = "",
                Cep = "",
                Profissao = "",
                Formacao = "",
                NivelFormacao = "",
                Instituicao = ""
            };

        }


        [Fact(DisplayName = "Adicionar Candidato com Sucesso")]
        public void ServiceCandidatos_Adicionar_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            // Act
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // assert
            Assert.True(candidatoservice.IncluirCandidato(CandidatoValidoInclusao).Consistente == true);
        }

        [Fact(DisplayName = "Adicionar Cadidato com Falha")]
        public void ServiceCandidatos_Adicionar_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // Act
            Assert.True(candidatoservice.IncluirCandidato(CandidatoInvalidoInclusao).Consistente == false);
            Assert.True(candidatoservice.IncluirCandidato(CandidatoInvalidoInclusao).ListaErros.Any());
        }


        [Fact(DisplayName = "Alterar Candidato com Sucesso")]
        public void ServiceCandidatos_Alterar_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // Act
            Assert.True(candidatoservice.AlterarCandidato(CandidatoValidoAlteracao).Consistente == true);
        }

        [Fact(DisplayName = "Alterar Candidato com Falha")]
        public void ServiceCandidatos_Alterar_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // Act
            Assert.True(candidatoservice.AlterarCandidato(CandidatoInvalidoAlteracao).Consistente == false);
            Assert.True(candidatoservice.AlterarCandidato(CandidatoInvalidoAlteracao).ListaErros.Any());
        }


        [Fact(DisplayName = "Excluir Candidato com Sucesso")]
        public void ServiceCandidatos_Excluir_DeveExecutarComSucesso()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // Act
            Assert.True(candidatoservice.ExcluirCandidato(10) != null);
        }

        [Fact(DisplayName = "Excluir Candidato com Falha")]
        public void ServiceCandidatos_Excluir_DeveExecutarComFalha()
        {
            // arrange
            var vagaRepo = new Mock<IRepositoryCandidatos>();
            var candidatoservice = new ServiceCandidatos(vagaRepo.Object);
            // Act
            Assert.True(candidatoservice.ExcluirCandidato(10).ListaErros.Any());
        }


    }
}
