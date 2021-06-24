using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.DTO
{
    public class CurriculumAlteracaoDTO
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public string AreaAtuacao { get; set; }
        public string Objetivo { get; set; }

    }
}
