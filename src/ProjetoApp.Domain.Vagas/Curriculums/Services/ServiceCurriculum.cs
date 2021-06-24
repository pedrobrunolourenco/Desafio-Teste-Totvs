using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Services
{
    public class ServiceCurriculum : IServiceCurriculum
    {
        private readonly IRepositoryCurriculum repoCur;
        public ServiceCurriculum(IRepositoryCurriculum _repoCur)
        {
            repoCur = _repoCur;
        }


        public IEnumerable<Curriculum> ObterListaDeCurriculumns()
        {
            return repoCur.ObterListaDeCurriculums();
        }

        public Curriculum ObterCurriculumPorId(int id)
        {
            return repoCur.ObeterCurriculumPorId(id);
        }

        public Curriculum VerificarSeCurriculumExiste(int IdCandidato)
        {
            return repoCur.VerificarSeCurriculumExiste(IdCandidato);
        }

        public Curriculum IncluirCurriculum(CurriculumInclusaoDTO cur)
        {
            var inclui = new Curriculum(0, cur.IdCandidato, cur.AreaAtuacao, cur.Objetivo);
            if (!inclui.Consistente) return inclui;
            if (VerificarSeCurriculumExiste(cur.IdCandidato) != null)
            {
                inclui.ListaErros.Add("Este curriculum já foi cadastrado!");
                return inclui;
            }
            repoCur.Adicionar(inclui);
            Salvar();
            return inclui;
        }


        public Curriculum AlterarCurriculum(CurriculumAlteracaoDTO cur)
        {
            var alterar = new Curriculum(cur.Id, cur.IdCandidato, cur.AreaAtuacao, cur.Objetivo);
            if (!alterar.Consistente) return alterar;
            if (VerificarSeCurriculumExiste(cur.IdCandidato) != null)
            {
                alterar.ListaErros.Add("Este curriculum já foi cadastrado!");
                return alterar;
            }
            repoCur.Atualizar(alterar);
            Salvar();
            return alterar;
        }

        public bool ExcluirCurriculum(int id)
        {
            return repoCur.ExclusaoDeCurriculum(id);
        }

        public void Salvar()
        {
            repoCur.Salvar();
        }

 
    }
}
