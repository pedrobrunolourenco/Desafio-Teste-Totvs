using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoApp.Domain.Vaga.DTO;
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
    public class SegurancaController : ControllerBase
    {
        /// <summary>
        /// Gera Token
        /// </summary>
        /// <response code="200">Gera um token válido caso a chave passada seja correta ou a mensagem Erro caso a chave seja incorreta</response>   
        [HttpPost]
        [AllowAnonymous]
        [Route("Gerar-Token")]
        public ActionResult GeraToken(LoginDTO login)
        {
            if (login.Login.ToUpper() == "ATS")
            {
                var token = GerarJwt(login.Login);
                return Ok(new
                {
                    Status = "200",
                    Retorno = token
                }); ;
            }
            return Ok(new
            {
                Status = "200",
                Retorno = "Erro"
            });
        }

        private string GerarJwt(string login)
        {
            var identityClaims = new ClaimsIdentity();
            var claim = new Claim("Usuario", login);
            identityClaims.AddClaim(claim);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("App-Teste-Pedro-Bruno");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        

    }
}
