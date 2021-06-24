using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IRepositoryHistoricoProfissional : IRepositoryBase<HistoricoProfisional>
    {
        IEnumerable<HistoricoProfisional> ObterLista();
        HistoricoProfisional ObeterPorId(int id);
    }
}
