using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Entidades;
using ProjetoApp.Domain.Candidato.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Candidato.Services
{
    public class ServiceCandidatos : IServiceCandidatos
    {
        private readonly IRepositoryCandidatos repoCandidatos;

        public ServiceCandidatos(IRepositoryCandidatos _repoCandidatos)
        {
            repoCandidatos = _repoCandidatos;
        }

        public IEnumerable<ListagemCandidatoDTO> ObterListaDeCandidatos()
        {
            return repoCandidatos.ObterListaDeCandidatos();
        }

        public Candidatos ObterCandidatoPorId(int id)
        {
            return repoCandidatos.ObeterCandidatoPorId(id);
        }


        public Candidatos IncluirCandidato(CandidatosInclusaoDTO candidato)
        {

            var candidatoinclui = new Candidatos(0, candidato.Nome, candidato.Cpf, candidato.DataNascimento, candidato.EstadoCivil, candidato.Genero, candidato.Telefone, candidato.Email, candidato.Logradouro, candidato.Bairro, candidato.Cidade, candidato.Uf, candidato.Cep, candidato.Profissao, candidato.Formacao, candidato.NivelFormacao, candidato.Instituicao);
            if (!candidatoinclui.Consistente) return candidatoinclui;
            repoCandidatos.Adicionar(candidatoinclui);
            Salvar();
            return candidatoinclui;
        }

        public Candidatos AlterarCandidato(CandidatosAlteracaoDTO candidato)
        {

            var candidatoaltera = new Candidatos(candidato.Id, candidato.Nome, candidato.Cpf, candidato.DataNascimento, candidato.EstadoCivil, candidato.Genero, candidato.Telefone, candidato.Email, candidato.Logradouro, candidato.Bairro, candidato.Cidade, candidato.Uf, candidato.Cep, candidato.Profissao, candidato.Formacao, candidato.NivelFormacao, candidato.Instituicao);
            if (!candidatoaltera.Consistente) return candidatoaltera;
            repoCandidatos.Atualizar(candidatoaltera);
            Salvar();
            return candidatoaltera;
        }

        public Candidatos ExcluirCandidato(int id)
        {
            var candidatoexclui = ObterCandidatoPorId(id);
            if (candidatoexclui != null)
            {
                repoCandidatos.DetachAllEntities();
                repoCandidatos.Remover(candidatoexclui);
                Salvar();
                return candidatoexclui;
            }
            candidatoexclui = new Candidatos(id, "", "", DateTime.Now, "", "", "", "","", "", "", "", "", "", "", "", "");
            candidatoexclui.ListaErros.Add("O candidato não foi localizado!");
            return candidatoexclui;
        }

        public void Salvar()
        {
            repoCandidatos.Salvar();
        }
    }
}

