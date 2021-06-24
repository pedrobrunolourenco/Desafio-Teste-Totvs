using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoApp.Domain.Candidatura.DTO;
using ProjetoApp.Domain.Candidatura.Intefaces;

namespace ProjetoApp.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize()]
    public class CandidaturasController : ControllerBase
    {

        private readonly IServiceCandidaturas _serviceCandidaturas;

        public CandidaturasController(IServiceCandidaturas serviceCandidaturas)
        {
            _serviceCandidaturas = serviceCandidaturas;
        }

        /// <summary>
        /// Retorna uma lista de candidaturas
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de candidaturas</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Candidatos-Inscritos-Em-Vagas")]
        public ActionResult ObterCandidatosCadastrados()
        {
            return Ok(_serviceCandidaturas.ObterCandidatosCadastrados());
        }

        /// <summary>
        /// Retorna um objeto candidatura e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto candidatura</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Candidatura-Por_Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceCandidaturas.ObeterCandidaturaPorId(id)); ;
        }

        /// <summary>
        /// Tenta INCLUIR uma candidatura de um candidato a uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão de uma candidatura, caso a lista esteja vazia a candidatura  foi incluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Candidatar")]
        public ActionResult AdicionarCandidatura(CandidaturasInclusaoDTO candidatura)
        {
            return Ok(_serviceCandidaturas.IncluirCandidatura(candidatura));
        }

        /// <summary>
        /// Tenta EXCLUIR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão da candidatura, caso a lista esteja vazia a candidatura foi excluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Cancelar-Candidatura")]
        public ActionResult ExcluirCandidatura(int id)
        {
            return Ok(_serviceCandidaturas.ExcluirCandidatura(id));
        }
    }
}
