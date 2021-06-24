using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApp.Domain.Candidato.Entidades;

namespace ProjetoApp.Infra.Data.Mapping
{
    public class CandidatosMapping : IEntityTypeConfiguration<Candidatos>
    {
        public void Configure(EntityTypeBuilder<Candidatos> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder.Ignore(c => c.ListaErros);
            builder.Ignore(c => c.Consistente);
            builder.OwnsOne(c => c.DadosCandidato).Property(x => x.DataNascimento).HasColumnType("datetime").HasColumnName("DataNascimento");
            builder.OwnsOne(c => c.DadosCandidato).Property(x => x.Nome).HasMaxLength(100).HasColumnName("Nome");
            builder.OwnsOne(c => c.DadosCandidato).Property(x => x.CPF).HasMaxLength(11).HasColumnName("Cpf");
            builder.OwnsOne(c => c.DadosCandidato).Property(x => x.EstadoCivil).HasMaxLength(1).HasColumnName("EstadoCivil");
            builder.OwnsOne(c => c.DadosCandidato ).Property(x => x.Genero).HasMaxLength(1).HasColumnName("Genero");
            builder.OwnsOne(c => c.DadosCandidato).Property(x => x.Telefone).HasMaxLength(1).HasColumnName("Telefone");
            builder.OwnsOne(c => c.DadosCandidato ).OwnsOne(c => c.EmailPF).Property(x => x.EnderecoEmail).HasMaxLength(200).HasColumnName("EnderecoEmail");
            builder.OwnsOne(c => c.DadosCandidato ).OwnsOne(c => c.EnderecoPF).Property(x => x.Logradouro).HasMaxLength(200).HasColumnName("Logradouro");
            builder.OwnsOne(c => c.DadosCandidato).OwnsOne(c => c.EnderecoPF).Property(x => x.Bairro).HasMaxLength(50).HasColumnName("Bairro");
            builder.OwnsOne(c => c.DadosCandidato).OwnsOne(c => c.EnderecoPF).Property(x => x.Cidade).HasMaxLength(50).HasColumnName("Cidade");
            builder.OwnsOne(c => c.DadosCandidato).OwnsOne(c => c.EnderecoPF).Property(x => x.UF).HasMaxLength(2).HasColumnName("Uf");
            builder.OwnsOne(c => c.DadosCandidato).OwnsOne(c => c.EnderecoPF).Property(x => x.CEP).HasMaxLength(8).HasColumnName("Cep");
            builder.Property(c => c.Profissao).HasMaxLength(100);
            builder.Property(c => c.Formacao).HasMaxLength(100);
            builder.Property(c => c.NivelFormacao).HasMaxLength(1);
            builder.Property(c => c.Instituicao).HasMaxLength(100);
            builder.ToTable("Candidatos");
        }
    }
}
