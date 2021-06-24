using System;

namespace ProjetoApp.Domain.Shared.ValueObjects
{
    public class PessoaFisica
    {

        protected PessoaFisica()
        {

        }

        public PessoaFisica(string nome, string cpf, DateTime datanascimento, string estadocivil, string genero, string telefone, string email,  string logradouro, string bairro, string cidade, string uf, string cep  )
        {
			Nome = nome;
			CPF = cpf;
			DataNascimento = datanascimento;
			EstadoCivil = estadocivil;
			Genero = genero;
			Telefone = telefone;
			EmailPF = new Email(email);
			EnderecoPF = new Endereco(logradouro, bairro, cidade, uf, cep);
		}

		public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Genero { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; set; }
        public Email EmailPF { get; private set; }
        public Endereco EnderecoPF { get; private set; }

        public bool NomeDeveSerPreenchido(string nome)
        {
            if (string.IsNullOrEmpty(nome)) return false;
            return true;
        }

        public bool NomeDeveTerTamanhoLimite(string nome, int tamanho)
        {
            if (!string.IsNullOrEmpty(nome) && nome.Length > tamanho) return false;
            return true;
        }

		public bool TelefoneDeveSerPreenchido(string telefone)
		{
			if (string.IsNullOrEmpty(telefone)) return false;
			return true;
		}

		public bool TelefoneDeveTerTamanhoLimite(string telefone)
		{
			if (!string.IsNullOrEmpty(telefone) && telefone.Length > 12 || telefone.Length < 7) return false;
			return true;
		}


		public bool EstadoCivilDeveSerValido(string estadocivil)
        {
			if(estadocivil != "C" && estadocivil != "S" &&  estadocivil != "D" && estadocivil != "O") return false;
			return true;
		}

		public bool GeneroDeveSerValido(string genero)
		{
			if (genero != "M" && genero != "F" && genero != "I") return false;
			return true;
		}

		public bool PessoaDeveTerUmaIdadeLimite(int idade)
		{
			var anos = DateTime.Today.Year - DataNascimento.Year;
			if (anos < idade) return false;
			return true;
		}


		public bool CPFDeveSerPreenchido(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;
            return true;
        }


		public bool CPFDeveTerTamanhoLimite(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf) && cpf.Length != 11) return false;
            return true;
        }

		public bool CPFDeveSerValido(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}



	}
}
