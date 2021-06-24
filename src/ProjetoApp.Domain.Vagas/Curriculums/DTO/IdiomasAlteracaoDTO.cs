using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Domain.Curriculums.DTO
{
    public class IdiomasAlteracaoDTO
    {
        public int Id { get; set; }
        public int IdCur { get; set; }
        public string Idioma { get; set; }
        public string Nivel { get; set; }
    }
}
