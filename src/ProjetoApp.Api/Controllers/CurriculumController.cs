using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoApp.Domain.Curriculums.DTO;
using ProjetoApp.Domain.Curriculums.Interfaces;

namespace ProjetoApp.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize()]
    public class CurriculumController : ControllerBase
    {
        private readonly IServiceCurriculum _serviceCur;

        public CurriculumController(IServiceCurriculum serviceCur)
        {
            _serviceCur = serviceCur;
        }

        /// <summary>
        /// Retorna uma lista de curriculuns
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de curriculuns</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Todos")]
        public ActionResult ObterTodos()
        {
            return Ok(_serviceCur.ObterListaDeCurriculumns());
        }

        /// <summary>
        /// Retorna um objeto curriculum e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto curriculum</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceCur.ObterCurriculumPorId(id));
        }

        /// <summary>
        /// Tenta INCLUIR um curriculum
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão do curriculum, caso a lista esteja vazia o curriculum foi incluída com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar(CurriculumInclusaoDTO cur)
        {
            return Ok(_serviceCur.IncluirCurriculum(cur));
        }

        /// <summary>
        /// Tenta ALTERAR um curriulum
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração do curriulum, caso a lista esteja vazia o curriculum foi alerado com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult Alterar(CurriculumAlteracaoDTO cur)
        {
            return Ok(_serviceCur.AlterarCurriculum(cur));
        }

        /// <summary>
        /// Tenta EXCLUIR um curriculum
        /// </summary>
        /// <response code="200">Retorna true se excluiu com sucesso </response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            return Ok(_serviceCur.ExcluirCurriculum(id));
        }






    }
}
