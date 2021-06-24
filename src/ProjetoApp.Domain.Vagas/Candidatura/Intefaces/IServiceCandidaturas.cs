using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Candidatura.Intefaces
{
    public interface IServiceCandidaturas
    {
        IEnumerable<ListagemConsultaCandidatosDTO> ObterCandidatosCadastrados();
        Candidaturas ObeterCandidaturaPorId(int id);
        Candidaturas VerificarSeCandidaturaExiste(int IdCandidato);
        Candidaturas IncluirCandidatura(CandidaturasInclusaoDTO vaga);
        Candidaturas ExcluirCandidatura(int id);
        void Salvar();
    }
}
