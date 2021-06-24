using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IServiceCurriculum
    {
        IEnumerable<Curriculum> ObterListaDeCurriculumns();
        Curriculum ObterCurriculumPorId(int id);
        Curriculum IncluirCurriculum(CurriculumInclusaoDTO cur);
        Curriculum AlterarCurriculum(CurriculumAlteracaoDTO cur);
        Curriculum VerificarSeCurriculumExiste(int IdCandidato);
        bool ExcluirCurriculum(int id);
        void Salvar();

    }
}
