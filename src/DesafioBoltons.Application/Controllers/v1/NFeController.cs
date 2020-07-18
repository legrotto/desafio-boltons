using DesafioBoltons.Domain.DTOs;
using DesafioBoltons.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioBoltons.Application.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class NFeController : Controller
    {
        private readonly INFeService _servico;

        public NFeController(INFeService servico) => _servico = servico;

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(NFeDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ClientErrorData), 400)]
        public async Task<IActionResult> GetById([FromQuery] BuscarNFeDTO model)
        {
            try
            {
                //Valida modelo
                if (model == null) model = new BuscarNFeDTO();

                return Ok(await _servico.BuscarTodos(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
