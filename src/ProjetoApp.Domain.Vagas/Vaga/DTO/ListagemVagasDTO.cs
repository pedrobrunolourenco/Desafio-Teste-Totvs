using System;

namespace ProjetoApp.Domain.Vaga.DTO
{
    public class ListagemVagasDTO
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Posicao { get; set; }
        public string EmpresaContratante { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

    }
}
