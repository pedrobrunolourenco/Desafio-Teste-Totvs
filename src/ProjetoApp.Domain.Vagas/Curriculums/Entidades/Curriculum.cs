using ProjetoApp.Domain.Shared.Entidades;
using System.Linq;

namespace ProjetoApp.Domain.Curriculums.Entidades
{
    public class Curriculum : EntidadeBase
    {
        protected Curriculum()
        {

        }

        public Curriculum(int id, int idcandidato, string areaatuacao, string objetivo)
        {
            Id = id;
            IdCandidato = idcandidato;
            AreaAtuacao = areaatuacao;
            Objetivo = objetivo;
            Consistente = EstaConsistente();
        }

        public int IdCandidato  { get; private set; }
        public string AreaAtuacao { get; private set; }
        public string Objetivo { get; private set; }


        public override bool EstaConsistente()
        {
            CandidatoDeveSerInformado();
            AreaDeAtuacaoDeveSerInformada();
            AreaDeAtuacaoDeveTerUmTamanhoLimite();
            ObjetivoDeveSerInformado();
            ObjetivoDeveTerUmTamanhoLimite();
            return !ListaErros.Any();
        }

        private void CandidatoDeveSerInformado()
        {
            if (IdCandidato <= 0) ListaErros.Add("Candidato deve ser informado.");
        }

        private void AreaDeAtuacaoDeveSerInformada()
        {
            if (string.IsNullOrEmpty(AreaAtuacao)) ListaErros.Add("Area de Atuação deve ser informada.");
        }

        private void AreaDeAtuacaoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(AreaAtuacao) && AreaAtuacao.Length>8000) ListaErros.Add("Area de Atuação deve ter um tamanho máximo de 8000 caracteres.");
        }

        private void ObjetivoDeveSerInformado()
        {
            if (string.IsNullOrEmpty(Objetivo)) ListaErros.Add("Objetivo deve ser informado.");
        }

        private void ObjetivoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Objetivo) && Objetivo.Length > 8000) ListaErros.Add("Objetivo deve ter um tamanho máximo de 8000 caracteres.");
        }

    }
}
