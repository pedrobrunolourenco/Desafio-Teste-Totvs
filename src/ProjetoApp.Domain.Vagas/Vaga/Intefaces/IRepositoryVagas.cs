using ProjetoApp.Domain.Shared.Interfaces.Repository;
using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Vaga.Intefaces
{
    public interface IRepositoryVagas : IRepositoryBase<Vagas>
    {
        IEnumerable<ListagemVagasDTO> ObterListaDeVagas();
        Vagas ObeterVagaPorId(int id);
    }
}
