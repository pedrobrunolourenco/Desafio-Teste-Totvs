using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Entidades;
using ProjetoApp.Domain.Candidato.Interfaces;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApp.Infra.Data.Repository.Candidato
{
    public class RepositoryCandidatos : RepositoryBase<Candidatos>, IRepositoryCandidatos
    {
        public RepositoryCandidatos(ContextEF context) : base(context)
        {

        }


        public IEnumerable<ListagemCandidatoDTO> ObterListaDeCandidatos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT Id, Nome, Cpf, Profissao FROM Candidatos WITH(NOLOCK) ORDER BY Nome
                          ");
            var retorno = Db.Database.GetDbConnection().Query<ListagemCandidatoDTO>(query.ToString());
            return retorno;
        }

        public Candidatos ObeterCandidatoPorId(int id)
        {
            return Listar().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
