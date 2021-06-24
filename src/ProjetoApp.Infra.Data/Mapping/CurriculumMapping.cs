using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Curriculums.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Infra.Data.Mapping
{
    public class CurriculumMapping : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder.Ignore(c => c.ListaErros);
            builder.Ignore(c => c.Consistente);
            builder.Property(c => c.AreaAtuacao).HasMaxLength(8000);
            builder.Property(c => c.Objetivo).HasMaxLength(8000);
            builder.ToTable("Curriculum");
        }
    }
}
