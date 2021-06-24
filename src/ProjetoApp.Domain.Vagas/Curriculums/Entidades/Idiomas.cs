using ProjetoApp.Domain.Shared.Entidades;
using System.Linq;

namespace ProjetoApp.Domain.Curriculums.Entidades
{
    public class Idiomas : EntidadeBase
    {
        protected Idiomas()
        {

        }

        public Idiomas(int id, int idcur, string idioma, string nivel)
        {
            Id = id;
            IdCur = idcur;
            Idioma = idioma;
            Nivel = nivel;
            Consistente = EstaConsistente();
        }

        public int IdCur { get; private set; }
        public string Idioma { get; private set; }
        public string Nivel { get; private set; }

        public override bool EstaConsistente()
        {
            IdDoCurriculumDeveSerInformado();
            IdiomaDeveSerInformado();
            IdiomaDeveTerUmTamanhoLimite();
            ValidarNivel();
            return !ListaErros.Any();
        }

        private void IdDoCurriculumDeveSerInformado()
        {
            if (IdCur <= 0) ListaErros.Add("Curriculum deve ser informado.");
        }

        private void IdiomaDeveSerInformado()
        {
            if (string.IsNullOrEmpty(Idioma)) ListaErros.Add("Idioma deve ser informado.");
        }

        private void IdiomaDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Idioma) && Idioma.Length > 50) ListaErros.Add("Idioma deve ter um tamanho máximo de 50 caracteres.");
        }

        private void ValidarNivel()
        {
            if (Nivel != "B" && Nivel != "I" && Nivel != "A") ListaErros.Add("Nivel deve ser ([B]ásico, [I]ntermediário, [A]vançado)");
        }





    }
}
