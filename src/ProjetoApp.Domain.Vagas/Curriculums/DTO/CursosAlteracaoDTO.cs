using System;

namespace ProjetoApp.Domain.Curriculums.DTO
{
    public class CursosAlteracaoDTO
    {
        public int Id { get; set; }
        public int IdCur { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string NomeCurso { get; set; }
        public string Instituicao { get; set; }

    }
}
