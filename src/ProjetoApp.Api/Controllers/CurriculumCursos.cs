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
    public class CurriculumCursos : ControllerBase
    {

        private readonly IServiceCursos _serviceCursos;

        public CurriculumCursos(IServiceCursos serviceCursos)
        {
            _serviceCursos = serviceCursos;
        }

        /// <summary>
        /// Retorna uma lista de cursos
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de cursos</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Todos")]
        public ActionResult ObterTodos()
        {
            return Ok(_serviceCursos.ObterListaDeCursos());
        }

        /// <summary>
        /// Retorna um objeto curso e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto curso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceCursos.ObterCursoPorId(id));
        }

        /// <summary>
        /// Tenta INCLUIR um curso
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão do curso, caso a lista esteja vazia o curso foi incluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar(CursosInclusaoDTO cur)
        {
            return Ok(_serviceCursos.IncluirCurso(cur));
        }

        /// <summary>
        /// Tenta ALTERAR um curso
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração do curso, caso a lista esteja vazia o curso foi alerado com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult Alterar(CursosAlteracaoDTO cur)
        {
            return Ok(_serviceCursos.AlterarCurso(cur));
        }

        /// <summary>
        /// Tenta EXCLUIR um curso
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão do curso, caso a lista esteja vazia o curso  foi excluído com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            return Ok(_serviceCursos.ExcluirCurso(id)); ;
        }




    }
}
