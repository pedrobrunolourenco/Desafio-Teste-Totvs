using ProjetoApp.Domain.Shared.Entidades;
using System.Linq;

namespace ProjetoApp.Domain.Candidatura.Entidades
{
    public class Candidaturas : EntidadeBase
    {
        protected Candidaturas()
        {

        }

        public Candidaturas(int id, int idcandidato, int idvaga)
        {
            Id = id;
            IdCandidato = idcandidato;
            IdVaga = idvaga;
            Consistente = EstaConsistente();
        }

        public override bool EstaConsistente()
        {
            IdDoCandidatoDeveSerInformado();
            IdDaVagaDeveSerInformada();
            return !ListaErros.Any();
        }

        public int IdCandidato { get; private set; }
        public int IdVaga { get; private set; }


        private void IdDoCandidatoDeveSerInformado()
        {
            if (IdCandidato <= 0) ListaErros.Add("Informe o candidato.");
        }

        private void IdDaVagaDeveSerInformada()
        {
            if (IdVaga <= 0) ListaErros.Add("Informe a vaga.");
        }


    }
}
