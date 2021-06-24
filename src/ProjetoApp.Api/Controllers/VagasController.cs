using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoApp.Domain.Vaga.DTO;
using ProjetoApp.Domain.Vaga.Intefaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoApp.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize()]
    public class VagasController : ControllerBase
    {


        #region construtor
        private readonly IServiceVagas _serviceVagas;

        public VagasController(IServiceVagas serviceVagas)
        {
            _serviceVagas = serviceVagas;
        }
        #endregion construtor

        #region get consultas

        /// <summary>
        /// Retorna uma lista de vagas
        /// </summary>
        /// <response code="200">Retorna uma lista de objetos de vagas</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Lista")]
        public ActionResult ObterListaVagas()
        {
            return Ok(_serviceVagas.ObterListaDeVagas());
        }



        /// <summary>
        /// Retorna um objeto vaga e recebe um Id
        /// </summary>
        /// <response code="200">Retorna um objeto vaga</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpGet]
        [Route("Obter-Por-Id")]
        public ActionResult ObterPoId(int id)
        {
            return Ok(_serviceVagas.ObterVagasPorId(id));

        }

        #endregion get consultas

        #region insert, update, delete


        /// <summary>
        /// Tenta INCLUIR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de inclusão da vaga, caso a lista esteja vazia  a vaga  foi incluída com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult AdicionarVaga(VagasInclusaoDTO vaga)
        {
            return Ok(_serviceVagas.IncluirVaga(vaga));
        }

        /// <summary>
        /// Tenta ALTERAR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de alteração da vaga, caso a lista esteja vazia  a vaga  foi alerada com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpPut]
        [Route("Alterar")]
        public ActionResult AlterarVaga(VagasAlteracaoDTO vaga)
        {
            return Ok(_serviceVagas.AlterarVaga(vaga));
        }


        /// <summary>
        /// Tenta EXCLUIR uma vaga
        /// </summary>
        /// <response code="200">Retorna uma lista com erros da tentativa de exclusão da vaga, caso a lista esteja vazia  a vaga  foi excluída com sucesso</response>   
        /// <response code="401">Caso token de acesso seja inválido</response>
        [HttpDelete]
        [Route("Excluir")]
        public ActionResult ExcluirVaga(int id)
        {
            return Ok(_serviceVagas.ExcluirVaga(id));
        }


        #endregion insert, update delete


    }
}
