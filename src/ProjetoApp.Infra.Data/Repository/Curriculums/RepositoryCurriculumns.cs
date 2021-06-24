using ProjetoApp.Domain.Curriculums.Interfaces;
using ProjetoApp.Infra.Data.Repository.Shared;
using ProjetoApp.Domain.Curriculums.Entidades;
using System.Collections.Generic;
using ProjetoApp.Infra.Data.Contextos;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace ProjetoApp.Infra.Data.Repository.Curriculums
{
    public class RepositoryCurriculumns : RepositoryBase<Curriculum>, IRepositoryCurriculum
    {
        public RepositoryCurriculumns(ContextEF context) : base(context)
        {

        }

        public IEnumerable<Curriculum> ObterListaDeCurriculums()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Curriculum WITH(NOLOCK) ORDER BY ID");
            var retorno = Db.Database.GetDbConnection().Query<Curriculum>(query.ToString());
            return retorno;
        }

        public Curriculum ObeterCurriculumPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Curriculum WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<Curriculum>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

        public Curriculum VerificarSeCurriculumExiste(int IdCandidato)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Curriculum WITH(NOLOCK) WHERE IDCANDIDATO=@IDCANDIDATO");
            var retorno = Db.Database.GetDbConnection().Query<Curriculum>(query.ToString(), new { IDCANDIDATO = IdCandidato }).FirstOrDefault();
            return retorno;
        }

        public bool ExclusaoDeCurriculum(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" 
                             BEGIN TRAN
                                DELETE FROM IDIOMAS WHERE IDCUR = @ID
                                DELETE FROM HISTORICOPROFISSIONAL WHERE IDCUR = @ID
                                DELETE FROM CURSOS WHERE IDCUR = @ID
                                DELETE FROM CURRICULUM WHERE ID = @ID
                             COMMIT
                          ");
            try
            {
                Db.Database.ExecuteSqlCommand(query.ToString(), new SqlParameter("@ID", id));
                return true;
            }
            catch( Exception E)
            {
                var teste = E.Message;
                return false;
            }
        }
    }
}
