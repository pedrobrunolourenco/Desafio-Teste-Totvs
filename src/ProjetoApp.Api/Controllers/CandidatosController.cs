using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoApp.Domain.Candidato.DTO;
using ProjetoApp.Domain.Candidato.Interfaces;

namespace ProjetoApp.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize()]
    public class CandidatosController : ControllerBase
    {
        private readonly IServiceCandidatos _serviceCandidatos;

        public CandidatosController(IServiceCandidatos serviceCandidatos)
        {
            _serviceCandidatos = serviceCandidatos;
        }

        /// <summary>
        /// Retorna uma lista de candidatos
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de candidatos</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Lista")]
        public ActionResult ObterListaCandidatos()
        {
            return Ok(_serviceCandidatos.ObterListaDeCandidatos());
        }



        /// <summary>
        /// Retorna um objeto candidato e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto candidato</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceCandidatos.ObterCandidatoPorId(id));
        }


        /// <summary>
        /// Tenta INCLUIR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão do candidato, caso a lista esteja vazia  o candidato  foi incluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult AdicionarCandidato(CandidatosInclusaoDTO candidato)
        {
            return Ok(_serviceCandidatos.IncluirCandidato(candidato));
        }

        /// <summary>
        /// Tenta ALTERAR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração do candidato, caso a lista esteja vazia o candidato  foi alerado com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult AlterarCandidato(CandidatosAlteracaoDTO candidato)
        {
            return Ok(_serviceCandidatos.AlterarCandidato(candidato));
        }


        /// <summary>
        /// Tenta EXCLUIR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão do candidato, caso a lista esteja vazia  o candidato foi excluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult ExcluirCandidato(int id)
        {
            return Ok(_serviceCandidatos.ExcluirCandidato(id));
        }

    }
}
