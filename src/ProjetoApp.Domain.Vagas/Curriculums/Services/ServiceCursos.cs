using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Services
{
    public class ServiceCursos : IServiceCursos
    {
        private readonly IRepositoryCursos repoCursos;

        public ServiceCursos(IRepositoryCursos _repoCursos)
        {
            repoCursos = _repoCursos;
        }


        public IEnumerable<Cursos> ObterListaDeCursos()
        {
            return repoCursos.ObterListaDeCusos();
        }

        public Cursos ObterCursoPorId(int id)
        {
            return repoCursos.ObeterCursosPorId(id);
        }


        public Cursos IncluirCurso(CursosInclusaoDTO cur)
        {
            var inclui = new Cursos(0, cur.IdCur, cur.DtInicio, cur.DtFim, cur.NomeCurso, cur.Instituicao);
            if (!inclui.Consistente) return inclui;
            repoCursos.Adicionar(inclui);
            Salvar();
            return inclui;
        }

        public Cursos AlterarCurso(CursosAlteracaoDTO cur)
        {
            var alterar = new Cursos(cur.Id, cur.IdCur, cur.DtInicio, cur.DtFim, cur.NomeCurso, cur.Instituicao);
            if (!alterar.Consistente) return alterar;
            repoCursos.Atualizar(alterar);
            Salvar();
            return alterar;
        }

        public Cursos ExcluirCurso(int id)
        {
            var exclui = ObterCursoPorId(id);
            if (exclui != null)
            {
                repoCursos.DetachAllEntities();
                repoCursos.Remover(exclui);
                Salvar();
                return exclui;
            }
            exclui = new Cursos(id, 0, DateTime.Now, DateTime.Now, "", "");
            exclui.ListaErros.Add("Curso não localizado!");
            return exclui;
        }

        public void Salvar()
        {
            repoCursos.Salvar();
        }

    }
}
