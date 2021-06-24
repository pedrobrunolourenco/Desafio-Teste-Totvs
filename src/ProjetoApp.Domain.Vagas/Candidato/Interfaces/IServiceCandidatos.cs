using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Candidato.Interfaces
{
    public interface IServiceCandidatos
    {
        IEnumerable<ListagemCandidatoDTO> ObterListaDeCandidatos();
        Candidatos ObterCandidatoPorId(int id);
        Candidatos IncluirCandidato(CandidatosInclusaoDTO candidato);
        Candidatos AlterarCandidato(CandidatosAlteracaoDTO candidato);
        Candidatos ExcluirCandidato(int id);
        void Salvar();
    }
}
