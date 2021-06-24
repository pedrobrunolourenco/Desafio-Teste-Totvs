using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.DTO
{
    public class HistoricoProfissionalAlteracaoDTO
    {
        public int Id { get; set; }
        public int IdCur { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string AtividadeExercida { get; set; }

    }
}
