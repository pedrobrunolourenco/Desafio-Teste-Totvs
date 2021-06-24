using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IServiceHistoricoProfissional
    {
        IEnumerable<HistoricoProfisional> ObterLista();
        HistoricoProfisional ObterPorId(int id);
        HistoricoProfisional Incluir(HistoricoProfissionalInclusaoDTO cur);
        HistoricoProfisional Alterar(HistoricoProfissionalAlteracaoDTO cur);
        HistoricoProfisional Excluir(int id);
        void Salvar();
    }
}
