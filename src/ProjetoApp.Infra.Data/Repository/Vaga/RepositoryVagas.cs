using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Entidades;
using ProjetoApp.Domain.Vaga.Intefaces;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Infra.Data.Repository.Vaga
{
    public class RepositoryVagas : RepositoryBase<Vagas>, IRepositoryVagas
    {
        public RepositoryVagas(ContextEF context) : base(context)
        {

        }

        public Vagas ObeterVagaPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM vagas WITH(NOLOCK) WHERE ID=@ID");
            var retorno = Db.Database.GetDbConnection().Query<Vagas>(query.ToString(), new { ID = id }).FirstOrDefault();
            return retorno;
        }

        public IEnumerable<ListagemVagasDTO> ObterListaDeVagas()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT Id, 
                                   DataAbertura, 
   	                               CASE Status
			                            WHEN 'A' THEN 'Vaga em Aberto'
			                            WHEN 'F' THEN 'Fechada'
		                           END Posicao, 
		                           EmpresaContratante, 
		                           Cargo, Salario 
                            FROM vagas WITH(NOLOCK) ORDER BY DataAbertura Desc 
                          ");
            var retorno = Db.Database.GetDbConnection().Query<ListagemVagasDTO>(query.ToString());
            return retorno;
        }

    }
}
