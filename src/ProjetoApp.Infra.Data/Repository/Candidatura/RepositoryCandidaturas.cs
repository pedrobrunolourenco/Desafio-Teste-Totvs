using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Entidades;
using ProjetoApp.Domain.Candidatura.Intefaces;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Infra.Data.Repository.Candidatura
{
    public class RepositoryCandidaturas : RepositoryBase<Candidaturas>, IRepositoryCandidaturas
    {

        public RepositoryCandidaturas(ContextEF context) : base(context)
        {

        }

        public IEnumerable<ListagemConsultaCandidatosDTO> ObterCandidatosCadastrados()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT  C1.Nome NomeCandidato, 
                                    V.DataAbertura, 
   	                                CASE V.Status
			                            WHEN 'A' THEN 'Vaga em Aberto'
			                            WHEN 'F' THEN 'Fechada'
		                            END Posicao, 
		                            V.EmpresaContratante, 
		                            V.Cargo, 
                                    V.Salario 
                            FROM Candidaturas C WITH(NOLOCK) 
							INNER JOIN Vagas V  WITH(NOLOCK) ON (V.Id = C.IdVaga)
							INNER JOIN Candidatos C1 WITH(NOLOCK) ON (C1.Id = C.IdCandidato)
							ORDER BY V.DataAbertura Desc 
                          ");
            var retorno = Db.Database.GetDbConnection().Query<ListagemConsultaCandidatosDTO>(query.ToString());
            return retorno;
        }

        public Candidaturas ObeterCandidaturaPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Candidaturas WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<Candidaturas>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

        public Candidaturas VerificarSeCandidaturaExiste(int IdCandidato)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM Candidaturas WITH(NOLOCK) WHERE IDCANDIDATO=@IDCANDIDATO");
            var retorno = Db.Database.GetDbConnection().Query<Candidaturas>(query.ToString(), new { IDCANDIDATO = IdCandidato }).FirstOrDefault();
            return retorno;
        }
    }
}
