using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoApp.Infra.Data.Mapping;
using System.IO;

namespace ProjetoApp.Infra.Data.Contextos
{
    public class ContextEF : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidaturasMapping());
            modelBuilder.ApplyConfiguration(new VagasMapping());
            modelBuilder.ApplyConfiguration(new CandidatosMapping());
            modelBuilder.ApplyConfiguration(new CurriculumMapping());
            modelBuilder.ApplyConfiguration(new CursosMapping());
            modelBuilder.ApplyConfiguration(new HistoricoProfissionalMapping());
            modelBuilder.ApplyConfiguration(new IdiomasMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(ApplicationExeDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("NomeConexao"));
        }

        public string ObterStringConexao()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(ApplicationExeDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            return config.GetConnectionString("NomeConexao");
        }

        public static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);
            return appRoot;
        }
    }

}
