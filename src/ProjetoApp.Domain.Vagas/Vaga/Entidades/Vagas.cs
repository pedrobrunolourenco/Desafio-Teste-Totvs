using ProjetoApp.Domain.Shared.Entidades;
using System;
using System.Linq;

namespace ProjetoApp.Domain.Vaga.Entidades
{
    public class Vagas : EntidadeBase
    {

        protected Vagas()
        {

        }

        public Vagas(int id,
                     string empresacontratante,
                     string locacao,
                     DateTime dataabertura,
                     string status,
                     string cargo,
                     string descricaovaga,
                     bool inglesfluente,
                     string genero,
                     string observacao,
                     decimal salario)
        {
            Id = id;
            EmpresaContratante = empresacontratante;
            Locacao = locacao;
            DataAbertura = dataabertura;
            Status = status;
            Cargo = cargo;
            DescricaoVaga = descricaovaga;
            InglesFluente = inglesfluente;
            Genero = genero;
            Observacao = observacao;
            Salario = salario;
            Consistente = EstaConsistente();
        }


        public string EmpresaContratante { get; private set; }
        public string Locacao { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public string Status { get; private set; }
        public string Cargo { get; private set; }
        public string DescricaoVaga { get; private set; }
        public bool InglesFluente { get; private set; }
        public bool Graduacao { get; private set; } // checkbox
        public string Genero { get; private set; }    // masculino - feminino 
        public string Observacao { get; private set; }
        public decimal Salario { get; private set; }


        public override bool EstaConsistente()
        {
            EmpresaContratanteDeveSerInformada();
            EmpresaContratanteDeveTerUmTamanhoLimiteDe100Caracteres();
            LocacaoDeveSerInformado();
            LocacaoDeveTerUmTamanhoLimiteDe100Caracteres();
            ValidarStatusDaVaga();
            CargoDeveSerInformado();
            CargoDeveTerUmTamanhoLimiteDe100Caracteres();
            DescricaoVagaDeveTerUmTamanhoMinimoEMaximo();
            ValidarGenero();
            ObservacaoDeveTerUmTamanhoMaximoDe200Caracteres();
            return !ListaErros.Any();
        }

        private void EmpresaContratanteDeveSerInformada()
        {
            if (string.IsNullOrEmpty(EmpresaContratante)) ListaErros.Add("Empresa Contratante Deve ser informada.");
        }

        private void EmpresaContratanteDeveTerUmTamanhoLimiteDe100Caracteres()
        {
            if (!string.IsNullOrEmpty(EmpresaContratante) && EmpresaContratante.Length > 100) ListaErros.Add("Empresa Contratante Deve ter no máximo 100 caracteres.");
        }

        private void LocacaoDeveSerInformado()
        {
            if (string.IsNullOrEmpty(Locacao)) ListaErros.Add("Locação Deve ser informado.");
        }

        private void LocacaoDeveTerUmTamanhoLimiteDe100Caracteres()
        {
            if (!string.IsNullOrEmpty(Locacao) && Locacao.Length > 100) ListaErros.Add("Locação Deve ter no máximo 100 caracteres.");
        }

        private void ValidarStatusDaVaga()
        {
            if (Status != "A" && Status != "F") ListaErros.Add("Status inválido.");
        }

        private void ValidarGenero()
        {
            if (Genero != "M" && Genero != "F" && Genero != "I") ListaErros.Add("Gênero Inválido.");
        }

        private void CargoDeveSerInformado()
        {
            if (string.IsNullOrEmpty(Cargo)) ListaErros.Add("Cargo Deve ser informado.");
        }

        private void CargoDeveTerUmTamanhoLimiteDe100Caracteres()
        {
            if (!string.IsNullOrEmpty(Cargo) && Cargo.Length > 100) ListaErros.Add("Cargo Deve ter no máximo 100 caracteres.");
        }

        private void DescricaoVagaDeveTerUmTamanhoMinimoEMaximo()
        {
            if ( (!string.IsNullOrEmpty(DescricaoVaga) && DescricaoVaga.Length < 30) || (!string.IsNullOrEmpty(DescricaoVaga) && DescricaoVaga.Length > 4000)) ListaErros.Add("A vaga deve ser melhor descrita.");
        }

        private void ObservacaoDeveTerUmTamanhoMaximoDe200Caracteres()
        {
            if (!string.IsNullOrEmpty(Observacao) && Observacao.Length > 200) ListaErros.Add("Observação Deve ter no máximo 200 caracteres.");
        }


    }


}
