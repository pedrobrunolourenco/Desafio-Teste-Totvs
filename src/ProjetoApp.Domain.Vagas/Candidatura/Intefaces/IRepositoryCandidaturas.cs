using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Candidatura.Intefaces
{
    public interface IRepositoryCandidaturas : IRepositoryBase<Candidaturas>
    {
        IEnumerable<ListagemConsultaCandidatosDTO> ObterCandidatosCadastrados();
        Candidaturas ObeterCandidaturaPorId(int id);
        Candidaturas VerificarSeCandidaturaExiste(int IdCandidato);
    }

}
