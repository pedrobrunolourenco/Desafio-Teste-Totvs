using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Vaga.Entidades;


namespace ProjetoApp.Infra.Data.Mapping
{
    public class VagasMapping : IEntityTypeConfiguration<Vagas>
    {
        public void Configure(EntityTypeBuilder<Vagas> builder)
        {
            builder.HasKey(v => new { v.Id });
            builder.Ignore(v => v.ListaErros);
            builder.Ignore(v => v.Consistente);
            builder.Property(v => v.EmpresaContratante).HasMaxLength(100);
            builder.Property(v => v.Locacao).HasMaxLength(100);
            builder.Property(v => v.Status).HasMaxLength(1);
            builder.Property(v => v.Cargo).HasMaxLength(100);
            builder.Property(v => v.DescricaoVaga).HasMaxLength(4000);
            builder.Property(v => v.Genero).HasMaxLength(1);
            builder.Property(v => v.Observacao).HasMaxLength(200);
            builder.Property(v => v.DataAbertura).HasColumnType("datetime");
            builder.Property(v => v.Graduacao).HasColumnType("bit");
            builder.Property(v => v.Salario).HasColumnType("decimal(18,2)");
            builder.ToTable("Vagas");
        }
    }
}
