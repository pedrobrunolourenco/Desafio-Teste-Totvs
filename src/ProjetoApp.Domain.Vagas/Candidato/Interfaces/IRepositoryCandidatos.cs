using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Candidato.Interfaces
{
    public interface IRepositoryCandidatos : IRepositoryBase<Candidatos>
    {
        IEnumerable<ListagemCandidatoDTO> ObterListaDeCandidatos();
        Candidatos ObeterCandidatoPorId(int id);

    }
}
