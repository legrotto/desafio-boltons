using Conexia.Domain.DTOs;
using Conexia.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Conexia.Application.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ITokenService _service;

        public AuthenticationController(ITokenService service)
        {
            _service = service;
        }            

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserAuthDTO model)
        {
            try
            {
                return Ok(_service.Authenticate(model));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //public async Task<ActionResult<dynamic>> Authenticate([FromBody]UserAuthDTO model)
        //{
            

        //    // Gera o Token
        //    var token = TokenService.GenerateToken(user);

        //    // Oculta a senha
        //    user.Senha = "";

        //    // Retorna os dados
        //    return new
        //    {
        //        user = user,
        //        token = token
        //    };
        //}

        //[HttpGet]
        //[Route("authenticated")]
        //[Authorize]
        //public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}