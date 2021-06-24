using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Curriculums.Entidades;
using ProjetoApp.Domain.Curriculums.Interfaces;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Infra.Data.Repository.Curriculums
{

    public class RepositoryCursos : RepositoryBase<Cursos>, IRepositoryCursos
    {
        public RepositoryCursos(ContextEF context) : base(context)
        {

        }

        public IEnumerable<Cursos> ObterListaDeCusos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Cursos WITH(NOLOCK) ORDER BY ID");
            var retorno = Db.Database.GetDbConnection().Query<Cursos>(query.ToString());
            return retorno;

        }

        public Cursos ObeterCursosPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Cursos WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<Cursos>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

    }

}
