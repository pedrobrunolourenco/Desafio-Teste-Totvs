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
    public class CurriculumHistoricoProfissional : ControllerBase
    {
        private readonly IServiceHistoricoProfissional _servicehp;

        public CurriculumHistoricoProfissional(IServiceHistoricoProfissional servicehp)
        {
            _servicehp = servicehp;
        }

        /// <summary>
        /// Retorna uma lista de Histórico Profissional
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de  Histórico Profissional</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Todos")]
        public ActionResult ObterTodos()
        {
            return Ok(_servicehp.ObterLista());
        }

        /// <summary>
        /// Retorna um objeto  Histórico Profissional e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto  Histórico Profissional</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_servicehp.ObterPorId(id));
        }

        /// <summary>
        /// Tenta INCLUIR um curso
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão do  Histórico Profissional, caso a lista esteja vazia o  Histórico Profissional foi incluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar(HistoricoProfissionalInclusaoDTO cur)
        {
            return Ok(_servicehp.Incluir(cur));
        }

        /// <summary>
        /// Tenta ALTERAR um Historico Profissional
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração do  Histórico Profissional, caso a lista esteja vazia o  Histórico Profissional foi alerado com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult Alterar(HistoricoProfissionalAlteracaoDTO cur)
        {
            return Ok(_servicehp.Alterar(cur));
        }

        /// <summary>
        /// Tenta EXCLUIR um curso
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão do  Histórico Profissional, caso a lista esteja vazia o  Histórico Profissional  foi excluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            return Ok(_servicehp.Excluir(id)); ;
        }


    }
}
