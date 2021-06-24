using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Curriculums.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Infra.Data.Mapping
{

    public class CursosMapping : IEntityTypeConfiguration<Cursos>
    {
        public void Configure(EntityTypeBuilder<Cursos> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder.Ignore(c => c.ListaErros);
            builder.Ignore(c => c.Consistente);
            builder.Property(c => c.DtInicio).HasColumnType("datetime");
            builder.Property(c => c.DtFim).HasColumnType("datetime");
            builder.Property(c => c.NomeCurso).HasMaxLength(200);
            builder.Property(c => c.Instituicao).HasMaxLength(200);
            builder.ToTable("Cursos");
        }
    }

}
