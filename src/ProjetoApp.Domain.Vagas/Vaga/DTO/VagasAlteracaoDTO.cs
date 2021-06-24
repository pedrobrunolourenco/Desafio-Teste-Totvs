using System;

namespace ProjetoApp.Domain.Vaga.DTO
{
    public class VagasAlteracaoDTO
    {
        public int Id { get; set; }
        public string EmpresaContratante { get; set; }
        public string Locacao { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Status { get; set; }
        public string Cargo { get; set; }
        public string DescricaoVaga { get; set; }
        public bool InglesFluente { get; set; }
        public bool Graduacao { get; set; }
        public string Genero { get; set; }
        public string Observacao { get; set; }
        public decimal Salario { get; set; }

    }
}
