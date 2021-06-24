using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Curriculums.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Infra.Data.Mapping
{
    public class HistoricoProfissionalMapping : IEntityTypeConfiguration<HistoricoProfisional>
    {
        public void Configure(EntityTypeBuilder<HistoricoProfisional> builder)
        {
            builder.HasKey(h => new { h.Id });
            builder.Ignore(h => h.ListaErros);
            builder.Ignore(h => h.Consistente);
            builder.Property(h => h.DtInicio).HasColumnType("datetime");
            builder.Property(h => h.DtFim).HasColumnType("datetime");
            builder.Property(h => h.AtividadeExercida).HasMaxLength(8000);
            builder.ToTable("HistoricoProfissional");
        }
    }
}
