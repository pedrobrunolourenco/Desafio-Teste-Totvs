using System.Collections.Generic;

namespace ProjetoApp.Domain.Shared.ValueObjects
{
    public class Endereco
    {
        protected Endereco()
        {

        }

        public Endereco(string logrodouro, string bairro, string cidade, string uf, string cep)
        {
            Logradouro = logrodouro;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CEP = cep;
        }

        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }

        public bool LogradouroDeveSerPreenchido(string logradouro)
        {
            if (string.IsNullOrEmpty(logradouro)) return false;
            return true;
        }

        public bool LogradouroDeveTerTamanhoLimite(string logradouro, int tamanho)
        {
            if (!string.IsNullOrEmpty(logradouro) && logradouro.Length > tamanho) return false;
            return true;
        }

        public bool CidadeDeveSerPreenchida(string cidade)
        {
            if (string.IsNullOrEmpty(cidade)) return false;
            return true;
        }

        public bool CidadeDeveTerTamanhoLimite(string cidade, int tamanho)
        {
            if (!string.IsNullOrEmpty(cidade) && cidade.Length > tamanho) return false;
            return true;
        }

        public bool BairroDeveSerPreenchido(string bairro)
        {
            if (string.IsNullOrEmpty(bairro)) return false;
            return true;
        }

        public bool BairroDeveTerTamanhoLimite(string bairro, int tamanho)
        {
            if (!string.IsNullOrEmpty(bairro) && bairro.Length > tamanho) return false;
            return true;
        }

        public bool UFDeveSerPreenchida(string uf)
        {
            if (string.IsNullOrEmpty(uf)) return false;
            return true;
        }
        public bool UFDeveTerTamanhoLimite(string uf)
        {
            if (!string.IsNullOrEmpty(uf) && uf.Length != 2) return false;
            return true;
        }

        public bool ValidarUF(string uf)
        {
            List<string> UFS = new List<string>
            {
                "AC", "AM","AL","AP","BA","CE","DF","ES","GO","MA","MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN","RS","RO","RR","SC","SE","SP","TO"
            };
            return UFS.Contains(uf);
        }

        public bool CEPDeveSerPreenchido(string cep)
        {
            if (string.IsNullOrEmpty(cep)) return false;
            return true;
        }

        public bool CEPDeveTerTamanhoLimite(string cep)
        {
            if (!string.IsNullOrEmpty(cep) && cep.Length != 8) return false;
            return true;
        }









    }

}