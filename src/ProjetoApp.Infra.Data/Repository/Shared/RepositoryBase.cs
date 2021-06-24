using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Shared.Interfaces.Repository;
using ProjetoApp.Infra.Data.Contextos;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoApp.Infra.Data.Repository.Shared
{
    public class RepositoryBase<TEntidade> : IRepositoryBase<TEntidade> where TEntidade : class
    {

        protected ContextEF Db;
        protected DbSet<TEntidade> DbSet;

        public RepositoryBase(ContextEF context)
        {
            Db = context;
            DbSet = Db.Set<TEntidade>();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = Db.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public IEnumerable<TEntidade> Listar()
        {
            return DbSet.ToList();
        }

        public void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public void Remover(TEntidade obj)
        {
            DbSet.Remove(obj);
        }

        public void Salvar()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}