using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IRepositoryCurriculum : IRepositoryBase<Curriculum>
    {
        IEnumerable<Curriculum> ObterListaDeCurriculums();
        Curriculum ObeterCurriculumPorId(int id);
        Curriculum VerificarSeCurriculumExiste(int IdCandidato);
        bool ExclusaoDeCurriculum(int id);

    }
}

