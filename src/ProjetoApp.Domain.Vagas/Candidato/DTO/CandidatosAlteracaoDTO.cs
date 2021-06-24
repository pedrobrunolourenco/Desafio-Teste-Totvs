using System;

namespace ProjetoApp.Domain.Candidato.DTO
{
    public class CandidatosAlteracaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Profissao { get; set; }
        public string Formacao { get; set; }
        public string NivelFormacao { get; set; }
        public string Instituicao { get; set; }
    }
}
