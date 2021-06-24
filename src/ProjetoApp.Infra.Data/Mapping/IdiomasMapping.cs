using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Curriculums.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApp.Infra.Data.Mapping
{
    public class IdiomasMapping : IEntityTypeConfiguration<Idiomas>
    {
        public void Configure(EntityTypeBuilder<Idiomas> builder)
        {
            builder.HasKey(i => new { i.Id });
            builder.Ignore(i => i.ListaErros);
            builder.Ignore(i => i.Consistente);
            builder.Property(i => i.Idioma).HasMaxLength(50);
            builder.Property(i => i.Nivel).HasMaxLength(1);
            builder.ToTable("Idiomas");
        }
    }
}
