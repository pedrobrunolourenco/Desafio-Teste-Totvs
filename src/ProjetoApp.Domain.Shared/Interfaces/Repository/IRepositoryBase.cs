using System;

namespace ProjetoApp.Domain.Shared.Interfaces.Repository
{
    public interface IRepositoryBase<TEntidade> : IDisposable where TEntidade : class
    {
        void DetachAllEntities();
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        void Salvar();
    }
}
