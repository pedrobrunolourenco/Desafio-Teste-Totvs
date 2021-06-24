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
    public class RepositoryHistoricoProfissional : RepositoryBase<HistoricoProfisional>, IRepositoryHistoricoProfissional
    {

        public RepositoryHistoricoProfissional(ContextEF context) : base(context)
        {

        }

        public IEnumerable<HistoricoProfisional> ObterLista()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM HistoricoProfissional WITH(NOLOCK) ORDER BY ID");
            var retorno = Db.Database.GetDbConnection().Query<HistoricoProfisional>(query.ToString());
            return retorno;
        }

        public HistoricoProfisional ObeterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM HistoricoProfissional WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<HistoricoProfisional>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

    }
}
