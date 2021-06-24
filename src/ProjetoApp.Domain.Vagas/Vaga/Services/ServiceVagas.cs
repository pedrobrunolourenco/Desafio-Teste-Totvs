using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Entidades;
using ProjetoApp.Domain.Vaga.Intefaces;
using System;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Vaga.Services
{
    public class ServiceVagas : IServiceVagas
    {

        private readonly IRepositoryVagas repoVagas;
        public ServiceVagas(IRepositoryVagas _repoVagas)
        {
            repoVagas = _repoVagas;
        }

        public IEnumerable<ListagemVagasDTO> ObterListaDeVagas()
        {
            return repoVagas.ObterListaDeVagas();
        }

        public Vagas ObterVagasPorId(int id)
        {
            return repoVagas.ObeterVagaPorId(id);
        }

        public Vagas IncluirVaga(VagasInclusaoDTO vaga)
        {
            var vagainclui = new Vagas(0, vaga.EmpresaContratante, vaga.Locacao, vaga.DataAbertura, vaga.Status, vaga.Cargo, vaga.DescricaoVaga, vaga.InglesFluente, vaga.Genero, vaga.Observacao, vaga.Salario);
            if (!vagainclui.Consistente) return vagainclui;
            repoVagas.Adicionar(vagainclui);
            Salvar();
            return vagainclui;
        }


        public Vagas AlterarVaga(VagasAlteracaoDTO vaga)
        {
            var vagaaltera = new Vagas(vaga.Id, vaga.EmpresaContratante, vaga.Locacao, vaga.DataAbertura, vaga.Status, vaga.Cargo, vaga.DescricaoVaga, vaga.InglesFluente, vaga.Genero, vaga.Observacao, vaga.Salario);
            if (!vagaaltera.Consistente) return vagaaltera;
            repoVagas.Atualizar(vagaaltera);
            Salvar();
            return vagaaltera;
        }

        public Vagas ExcluirVaga(int id)
        {
            var vagaexclui = ObterVagasPorId(id);
            if (vagaexclui != null)
            {
                repoVagas.DetachAllEntities();
                repoVagas.Remover(vagaexclui);
                Salvar();
                return vagaexclui;
            }
            vagaexclui = new Vagas(id, "", "", DateTime.Now, "", "", "", false, "", "", 0M);
            vagaexclui.ListaErros.Add("A vaga não foi localizada!");
            return vagaexclui;
        }

        public void Salvar()
        {
            repoVagas.Salvar();
        }
    }
}
