namespace ProjetoApp.Domain.Shared.ValueObjects
{
    public class Email
    {
        protected Email()
        {

        }
        public Email(string endereco)
        {
            EnderecoEmail = endereco;
        }

        public string EnderecoEmail { get; private set; }

        public bool EmailDeveSerPreenchido(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return true;
        }

        public bool EmailDeveTerTamanhoLimite(string email, int tamanho)
        {
            if (!string.IsNullOrEmpty(email) && email.Length > tamanho) return false;
            return true;
        }

        public bool EmailDeveSerValido(string email)
        {
            if(!string.IsNullOrEmpty(email))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }




    }
}
