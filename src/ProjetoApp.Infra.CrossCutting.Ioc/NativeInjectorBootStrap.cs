using Microsoft.Extensions.DependencyInjection;
using ProjetoApp.Domain.Candidato.Interfaces;
using ProjetoApp.Domain.Candidato.Services;
using ProjetoApp.Domain.Candidatura.Intefaces;
using ProjetoApp.Domain.Candidatura.Services;
using ProjetoApp.Domain.Curriculums.Interfaces;
using ProjetoApp.Domain.Curriculums.Services;
using ProjetoApp.Domain.Vaga.Intefaces;
using ProjetoApp.Domain.Vaga.Services;
using ProjetoApp.Infra.Data.Contextos;
using ProjetoApp.Infra.Data.Repository.Candidato;
using ProjetoApp.Infra.Data.Repository.Candidatura;
using ProjetoApp.Infra.Data.Repository.Curriculums;
using ProjetoApp.Infra.Data.Repository.Vaga;

namespace ProjetoApp.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrap
    {
        public static void RegisterServices(IServiceCollection service)
        {
            #region OUTROS
            service.AddScoped<ContextEF>();
            #endregion OUTROS

            #region services
            service.AddScoped<IServiceVagas, ServiceVagas>();
            service.AddScoped<IServiceCandidatos, ServiceCandidatos>();
            service.AddScoped<IServiceCandidaturas, ServiceCandidaturas>();
            service.AddScoped<IServiceCurriculum, ServiceCurriculum>();
            service.AddScoped<IServiceCursos, ServiceCursos>();
            service.AddScoped<IServiceHistoricoProfissional, ServiceHistoricoProfissional>();
            service.AddScoped<IServiceIdiomas, ServiceIdiomas>();
            #endregion services

            #region repository
            service.AddScoped<IRepositoryVagas, RepositoryVagas>();
            service.AddScoped<IRepositoryCandidatos, RepositoryCandidatos>();
            service.AddScoped<IRepositoryCandidaturas, RepositoryCandidaturas>();
            service.AddScoped<IRepositoryCurriculum, RepositoryCurriculumns>();
            service.AddScoped<IRepositoryCursos, RepositoryCursos>();
            service.AddScoped<IRepositoryHistoricoProfissional, RepositoryHistoricoProfissional>();
            service.AddScoped<IRepositoryIdiomas, RepositoryIdiomas>();
            #endregion repositoru



        }
    }
}
