using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.DTO
{
    public class HistoricoProfissionalInclusaoDTO
    {
        public int IdCur { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string AtividadeExercida { get; set; }

    }
}
