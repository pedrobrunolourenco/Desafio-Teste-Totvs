using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Services
{
    public class ServiceHistoricoProfissional : IServiceHistoricoProfissional
    {

        private readonly IRepositoryHistoricoProfissional repoHP;
        public ServiceHistoricoProfissional(IRepositoryHistoricoProfissional _repoHP)
        {
            repoHP = _repoHP;
        }

        public IEnumerable<HistoricoProfisional> ObterLista()
        {
            return repoHP.ObterLista();
        }

        public HistoricoProfisional ObterPorId(int id)
        {
            return repoHP.ObeterPorId(id);
        }

        public HistoricoProfisional Incluir(HistoricoProfissionalInclusaoDTO cur)
        {
            var inclui = new HistoricoProfisional(0, cur.IdCur, cur.DtInicio, cur.DtFim, cur.AtividadeExercida);
            if (!inclui.Consistente) return inclui;
            repoHP.Adicionar(inclui);
            Salvar();
            return inclui;

        }


        public HistoricoProfisional Alterar(HistoricoProfissionalAlteracaoDTO cur)
        {
            var alterar = new HistoricoProfisional(cur.Id, cur.IdCur, cur.DtInicio, cur.DtFim, cur.AtividadeExercida);
            if (!alterar.Consistente) return alterar;
            repoHP.Atualizar(alterar);
            Salvar();
            return alterar;

        }

        public HistoricoProfisional Excluir(int id)
        {
            var exclui = ObterPorId(id);
            if (exclui != null)
            {
                repoHP.DetachAllEntities();
                repoHP.Remover(exclui);
                Salvar();
                return exclui;
            }
            exclui = new HistoricoProfisional(id, 0, DateTime.Now, DateTime.Now, "");
            exclui.ListaErros.Add("Histórico Profissional não localizado!");
            return exclui;
        }

        public void Salvar()
        {
            repoHP.Salvar();
        }
    }
}
