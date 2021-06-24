using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IRepositoryIdiomas : IRepositoryBase<Idiomas>
    {
        IEnumerable<Idiomas> ObterLista();
        Idiomas ObeterPorId(int id);
    }

}
