using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Infra.Data.Repository.Curriculums
{
    public class RepositoryIdiomas : RepositoryBase<Idiomas>, IRepositoryIdiomas
    {

        public RepositoryIdiomas(ContextEF context) : base(context)
        {

        }


        public IEnumerable<Idiomas> ObterLista()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Idiomas WITH(NOLOCK) ORDER BY ID");
            var retorno = Db.Database.GetDbConnection().Query<Idiomas>(query.ToString());
            return retorno;
        }

        public Idiomas ObeterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Idiomas WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<Idiomas>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

    }
}
