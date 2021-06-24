using ProjetoApp.Domain.Shared.Entidades;
using ProjetoApp.Domain.Shared.ValueObjects;
using System;
using System.Linq;

namespace ProjetoApp.Domain.Candidato.Entidades
{
    public class Candidatos : EntidadeBase
    {
        protected Candidatos()
        {

        }

        public Candidatos(    int id,
                              string nome, 
                              string cpf, 
                              DateTime datanascimento, 
                              string estadocivil, 
                              string genero, 
                              string telefone,
                              string email, 
                              string logradouro, 
                              string bairro, 
                              string cidade, 
                              string uf, 
                              string cep,
                              string profisso,
                              string formacao,
                              string nivelformacao,
                              string instituicao
                          )
        {
            Id = id;
            DadosCandidato = new PessoaFisica(nome, cpf, datanascimento, estadocivil, genero, telefone, email, logradouro, bairro, cidade, uf, cep);
            Profissao = profisso;
            Formacao = formacao;
            NivelFormacao = nivelformacao;
            Instituicao = instituicao;
            Consistente = EstaConsistente();
        }


        public PessoaFisica DadosCandidato { get; private set; }
        public string Profissao { get; private set; }
        public string Formacao { get; private set; }
        public string NivelFormacao { get; private set; }  //   Medio - Graduação - Doutorado
        public string Instituicao { get; private set; }


        public override bool EstaConsistente()
        {
            NomeDoCandidatoDeveSerInformado();
            NomeDoCandidatoDeveTerUmTamanhoLimite();
            CPFdDoCandidatoDeveSerInformado();
            CPFDoCandidatoDeveTer11Caracteres();
            CPFDeveSerValido();
            CandidatoDeveTerUmaIdadeMinima();
            ValidarEstadoCivil();
            ValidarGenero();
            TelefoneDoCandidatoDeveSerInformado();
            TelefoneDoCandidatoDeveTerTamanhoLimite();
            EmailDoCandidatoDeveSerInformado();
            EmailDoCandidatoDeveTerTamanhoLimite();
            EmailDoCandidatoDeveSerValido();
            LogadouroDoCandidatoDeveSerInformado();
            LogradouroDoCandidatoDeveTerUmTamanhoLimite();
            BairroDoCandidatoDeveSerInformado();
            BairroDoCandidatoDeveTerUmTamanhoLimite();
            CidadeDoCandidatoDeveSerInformada();
            CidadeDoCandidatoDeveTerUmTamanhoLimite();
            CEPDoCandidatoDeveSerInformado();
            CEPDoCandidatoDeveTer8Caracteres();
            UFDoCandidatoDeveSerInformada();
            UFDoCandidatoDeveTer2Caracteres();
            UFDeveSerValida();
            ProfissaoDoCandidatoDeveSerInformada();
            ProfissaoDoCandidatoDeveTerUmTamanhoLimite();
            FormacaoDoCandidatoDeveSerInformada();
            FormacaoDoCandidatoDeveTerUmTamanhoLimite();
            InstituicaoDeveSerInformada();
            InstituicaoDeveTerUmTamanhoLimite();
            ValidarNivelDeFormacao();
            return !ListaErros.Any();
        }



        private void NomeDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.NomeDeveSerPreenchido(DadosCandidato.Nome)) ListaErros.Add("Nome do candidado deve ser preenchido.");
        }

        private void NomeDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!DadosCandidato.NomeDeveTerTamanhoLimite(DadosCandidato.Nome,100)) ListaErros.Add("Nome do candidado deve ter no máximo 100 caracteres.");
        }

        private void CPFdDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.CPFDeveSerPreenchido(DadosCandidato.CPF)) ListaErros.Add("CPF do candidado deve ser preenchido.");
        }

        private void CPFDoCandidatoDeveTer11Caracteres()
        {
            if (!DadosCandidato.CPFDeveTerTamanhoLimite(DadosCandidato.CPF)) ListaErros.Add("CPF deve ter 11 caracteres.");
        }
        private void CPFDeveSerValido()
        {
            if (!DadosCandidato.CPFDeveSerValido(DadosCandidato.CPF)) ListaErros.Add("Informe um CPF válido.");
        }

        private void CandidatoDeveTerUmaIdadeMinima()
        {
            if (!DadosCandidato.PessoaDeveTerUmaIdadeLimite(18)) ListaErros.Add("O candidato deve ter no mínimo 18 anos.");
        }

        private void ValidarEstadoCivil()
        {
            if (!DadosCandidato.EstadoCivilDeveSerValido(DadosCandidato.EstadoCivil)) ListaErros.Add("Estado Civil inválido.");
        }

        private void ValidarGenero()
        {
            if (!DadosCandidato.GeneroDeveSerValido(DadosCandidato.Genero)) ListaErros.Add("Gênero inválido.");
        }

        private void TelefoneDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.TelefoneDeveSerPreenchido(DadosCandidato.Telefone)) ListaErros.Add("Telefone do candidado deve ser preenchido.");
        }

        private void TelefoneDoCandidatoDeveTerTamanhoLimite()
        {
            if (!DadosCandidato.TelefoneDeveTerTamanhoLimite(DadosCandidato.Telefone)) ListaErros.Add("Telefone do candidado deve ter no máximo 12 caracteres e no mínimo 7.");
        }

        private void EmailDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.EmailPF.EmailDeveSerPreenchido(DadosCandidato.EmailPF.EnderecoEmail)) ListaErros.Add("Email do candidado deve ser preenchido.");
        }

        private void EmailDoCandidatoDeveTerTamanhoLimite()
        {
            if (!DadosCandidato.EmailPF.EmailDeveTerTamanhoLimite(DadosCandidato.EmailPF.EnderecoEmail,200)) ListaErros.Add("Email do candidado deve ter no máximo 200 caracteres.");
        }

        private void EmailDoCandidatoDeveSerValido()
        {
            if (!DadosCandidato.EmailPF.EmailDeveSerValido(DadosCandidato.EmailPF.EnderecoEmail)) ListaErros.Add("Informe um Email válido.");
        }


        private void LogadouroDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.EnderecoPF.LogradouroDeveSerPreenchido(DadosCandidato.EnderecoPF.Logradouro)) ListaErros.Add("Logradouro do candidado deve ser preenchido.");
        }

        private void LogradouroDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!DadosCandidato.EnderecoPF.LogradouroDeveTerTamanhoLimite(DadosCandidato.EnderecoPF.Logradouro,200)) ListaErros.Add("Logradouro do candidato deve ter no máximo 200 caracteres.");
        }

        private void BairroDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.EnderecoPF.BairroDeveSerPreenchido(DadosCandidato.EnderecoPF.Bairro)) ListaErros.Add("Bairro do candidado deve ser preenchido.");
        }

        private void BairroDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!DadosCandidato.EnderecoPF.BairroDeveTerTamanhoLimite(DadosCandidato.EnderecoPF.Bairro, 50)) ListaErros.Add("Bairo do candidato deve ter no máximo 50 caracteres.");
        }

        private void CidadeDoCandidatoDeveSerInformada()
        {
            if (!DadosCandidato.EnderecoPF.CidadeDeveSerPreenchida(DadosCandidato.EnderecoPF.Cidade)) ListaErros.Add("Cidade do candidado deve ser preenchida.");
        }

        private void CidadeDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!DadosCandidato.EnderecoPF.CidadeDeveTerTamanhoLimite(DadosCandidato.EnderecoPF.Cidade, 50)) ListaErros.Add("Cidade do candidato deve ter no máximo 50 caracteres.");
        }

        private void CEPDoCandidatoDeveSerInformado()
        {
            if (!DadosCandidato.EnderecoPF.CEPDeveSerPreenchido(DadosCandidato.EnderecoPF.CEP)) ListaErros.Add("CEP do candidado deve ser preenchido.");
        }

        private void CEPDoCandidatoDeveTer8Caracteres()
        {
            if (!DadosCandidato.EnderecoPF.CEPDeveTerTamanhoLimite(DadosCandidato.EnderecoPF.CEP)) ListaErros.Add("O CEP deve ter 8 caracteres.");
        }


        private void UFDoCandidatoDeveSerInformada()
        {
            if (!DadosCandidato.EnderecoPF.UFDeveSerPreenchida(DadosCandidato.EnderecoPF.UF)) ListaErros.Add("UF do candidado deve ser preenchida.");
        }

        private void UFDoCandidatoDeveTer2Caracteres()
        {
            if (!DadosCandidato.EnderecoPF.UFDeveTerTamanhoLimite(DadosCandidato.EnderecoPF.UF)) ListaErros.Add("A UF deve ter 2 caracteres.");
        }

        private void UFDeveSerValida()
        {
            if (!DadosCandidato.EnderecoPF.ValidarUF(DadosCandidato.EnderecoPF.UF)) ListaErros.Add("Informe uma UF válida.");
        }


        private void ProfissaoDoCandidatoDeveSerInformada()
        {
            if (string.IsNullOrEmpty(Profissao)) ListaErros.Add("Profissão do candidado deve ser preenchida.");
        }

        private void ProfissaoDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Profissao) && Profissao.Length > 100) ListaErros.Add("Profissao do candidado deve ter no máximo 100 caracteres.");
        }

        private void FormacaoDoCandidatoDeveSerInformada()
        {
            if (string.IsNullOrEmpty(Formacao)) ListaErros.Add("Formacao do candidado deve ser preenchida.");
        }

        private void FormacaoDoCandidatoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Formacao) && Formacao.Length > 100) ListaErros.Add("Formacao do candidado deve ter no máximo 100 caracteres.");
        }

        private void InstituicaoDeveSerInformada()
        {
            if (string.IsNullOrEmpty(Instituicao)) ListaErros.Add("Instituição de Formacao do candidado deve ser preenchida.");
        }

        private void InstituicaoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Formacao) && Formacao.Length > 100) ListaErros.Add("Instituição de Formacao do candidado deve ter no máximo 100 caracteres.");
        }

        private void ValidarNivelDeFormacao()
        {
            if (NivelFormacao != "M" && NivelFormacao != "G" && NivelFormacao != "D") ListaErros.Add("Nível de Graduação não aceitável.");
        }


    }
}













