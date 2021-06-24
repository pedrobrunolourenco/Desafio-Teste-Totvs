using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IRepositoryCursos : IRepositoryBase<Cursos>
    {
        IEnumerable<Cursos> ObterListaDeCusos();
        Cursos ObeterCursosPorId(int id);
    }
}
