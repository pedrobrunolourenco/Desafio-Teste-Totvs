using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Interfaces
{
    public interface IServiceIdiomas
    {
        IEnumerable<Idiomas> ObterLista();
        Idiomas ObterPorId(int id);
        Idiomas Incluir(IndiomasInclusaoDTO cur);
        Idiomas Alterar(IdiomasAlteracaoDTO cur);
        Idiomas Excluir(int id);
        void Salvar();

    }
}
