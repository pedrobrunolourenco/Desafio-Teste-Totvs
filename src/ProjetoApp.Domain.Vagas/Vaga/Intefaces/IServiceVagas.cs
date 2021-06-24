using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Entidades;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Vaga.Intefaces
{
    public interface IServiceVagas
    {
        IEnumerable<ListagemVagasDTO> ObterListaDeVagas();
        Vagas ObterVagasPorId(int id);
        Vagas IncluirVaga(VagasInclusaoDTO vaga);
        Vagas AlterarVaga(VagasAlteracaoDTO vaga);
        Vagas ExcluirVaga(int id);
        void Salvar();
    }
}
