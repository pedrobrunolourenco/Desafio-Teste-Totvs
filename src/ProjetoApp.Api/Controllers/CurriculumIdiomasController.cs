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
    public class CurriculumIdiomasController : ControllerBase
    {
        private readonly IServiceIdiomas _serviceIdiomas;

        public CurriculumIdiomasController(IServiceIdiomas serviceIdiomas)
        {
            _serviceIdiomas = serviceIdiomas;
        }

        /// <summary>
        /// Retorna uma lista de Idiomas
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de Idiomas</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Todos")]
        public ActionResult ObterTodos()
        {
            return Ok(_serviceIdiomas.ObterLista());
        }

        /// <summary>
        /// Retorna um objeto Idiomas e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto Idiomas</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceIdiomas.ObterPorId(id));
        }

        /// <summary>
        /// Tenta INCLUIR um Idioma
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão de Idiomas, caso a lista esteja vazia o Idioma foi incluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar(IndiomasInclusaoDTO cur)
        {
            return Ok(_serviceIdiomas.Incluir(cur));
        }

        /// <summary>
        /// Tenta ALTERAR um Idioma
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração do idioma, caso a lista esteja vazia o idioma foi alerado com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult Alterar(IdiomasAlteracaoDTO cur)
        {
            return Ok(_serviceIdiomas.Alterar(cur));
        }

        /// <summary>
        /// Tenta EXCLUIR um idioma
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão do idioma, caso a lista esteja vazia o  idioma  foi excluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            return Ok(_serviceIdiomas.Excluir(id)); ;
        }
    }
}
