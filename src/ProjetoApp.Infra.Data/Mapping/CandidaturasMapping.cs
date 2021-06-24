using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Candidatura.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Infra.Data.Mapping
{
    public class CandidaturasMapping : IEntityTypeConfiguration<Candidaturas>
    {
        public void Configure(EntityTypeBuilder<Candidaturas> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder.Ignore(c => c.ListaErros);
            builder.Ignore(c => c.Consistente);
        }
    }
}
