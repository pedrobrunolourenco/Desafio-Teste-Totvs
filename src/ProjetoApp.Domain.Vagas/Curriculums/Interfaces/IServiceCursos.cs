using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IServiceCursos
    {
        IEnumerable<Cursos> ObterListaDeCursos();
        Cursos ObterCursoPorId(int id);
        Cursos IncluirCurso(CursosInclusaoDTO cur);
        Cursos AlterarCurso(CursosAlteracaoDTO cur);
        Cursos ExcluirCurso(int id);
        void Salvar();

    }
}
