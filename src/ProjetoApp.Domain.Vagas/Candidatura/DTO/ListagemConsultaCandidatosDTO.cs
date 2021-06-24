using System;

namespace ProjetoApp.Domain.Candidatura.DTO
{
    public class ListagemConsultaCandidatosDTO
    {
        public string NomeCandidato { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Posicao { get; set; }
        public string EmpresaContratante { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
