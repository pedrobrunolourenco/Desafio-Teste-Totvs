using System.Collections.Generic;

namespace ProjetoApp.Domain.Shared.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            ListaErros = new List<string>();
            Consistente = false;
        }
        public int Id { get; protected set; }
        public bool Consistente { get; protected set; }
        public List<string> ListaErros { get; protected set; }

        public abstract bool EstaConsistente();
    }
}
