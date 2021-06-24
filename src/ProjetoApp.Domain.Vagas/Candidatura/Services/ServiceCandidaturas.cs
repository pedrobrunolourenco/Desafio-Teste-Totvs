using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Entidades;
using ProjetoApp.Domain.Candidatura.Intefaces;
using System.Collections.Generic;

namespace ProjetoApp.Domain.Candidatura.Services
{
    public class ServiceCandidaturas : IServiceCandidaturas
    {

        private readonly IRepositoryCandidaturas repoCandidaturas;

        public ServiceCandidaturas(IRepositoryCandidaturas _repoCandidaturas)
        {
            repoCandidaturas = _repoCandidaturas;
        }

        public IEnumerable<ListagemConsultaCandidatosDTO> ObterCandidatosCadastrados()
        {
            return repoCandidaturas.ObterCandidatosCadastrados();
        }

        public Candidaturas ObeterCandidaturaPorId(int id)
        {
            return repoCandidaturas.ObeterCandidaturaPorId(id);
        }

        public Candidaturas VerificarSeCandidaturaExiste(int IdCandidato)
        {
            return repoCandidaturas.VerificarSeCandidaturaExiste(IdCandidato);
        }

        public Candidaturas IncluirCandidatura(CandidaturasInclusaoDTO candidatura)
        {
            var inclui = new Candidaturas(0, candidatura.IdCandidato, candidatura.IdVaga);
            if (!inclui.Consistente) return inclui;
            if (VerificarSeCandidaturaExiste(candidatura.IdCandidato) != null)
            {
                inclui.ListaErros.Add("Este candidato já se inscreveu nesta vaga!");
                return inclui;
            }
            repoCandidaturas.Adicionar(inclui);
            Salvar();
            return inclui;
        }

        public Candidaturas ExcluirCandidatura(int id)
        {
            var exclui = ObeterCandidaturaPorId(id);
            if (exclui != null)
            {
                repoCandidaturas.DetachAllEntities();
                repoCandidaturas.Remover(exclui);
                Salvar();
                return exclui;
            }
            exclui = new Candidaturas(id, 0, 0);
            exclui.ListaErros.Add("A vaga não foi localizada!");
            return exclui;
        }


        public void Salvar()
        {
            repoCandidaturas.Salvar();
        }

    }
}
