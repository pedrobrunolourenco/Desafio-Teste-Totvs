using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Curriculums.Services
{
    public class ServiceIdiomas : IServiceIdiomas
    {

        private readonly IRepositoryIdiomas repoIdiomas;
        public ServiceIdiomas(IRepositoryIdiomas _repoIdiomas)
        {
            repoIdiomas = _repoIdiomas;
        }

        public IEnumerable<Idiomas> ObterLista()
        {
            return repoIdiomas.ObterLista();
        }

        public Idiomas ObterPorId(int id)
        {
            return repoIdiomas.ObeterPorId(id);
        }

        public Idiomas Incluir(IndiomasInclusaoDTO cur)
        {
            var inclui = new Idiomas(0, cur.IdCur, cur.Idioma, cur.Nivel);
            if (!inclui.Consistente) return inclui;
            repoIdiomas.Adicionar(inclui);
            Salvar();
            return inclui;

        }

        public Idiomas Alterar(IdiomasAlteracaoDTO cur)
        {
            var altera = new Idiomas(cur.Id, cur.IdCur, cur.Idioma, cur.Nivel);
            if (!altera.Consistente) return altera;
            repoIdiomas.Atualizar (altera);
            Salvar();
            return altera;
        }

        public Idiomas Excluir(int id)
        {
            var exclui = ObterPorId(id);
            if (exclui != null)
            {
                repoIdiomas.DetachAllEntities();
                repoIdiomas.Remover(exclui);
                Salvar();
                return exclui;
            }
            exclui = new Idiomas(id, 0,  "", "");
            exclui.ListaErros.Add("Idioma não localizado!");
            return exclui;
        }

        public void Salvar()
        {
            repoIdiomas.Salvar();
        }
    }
}
