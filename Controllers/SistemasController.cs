using ProducaoTematicaAPI.Models;
using ProducaoTematicaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducaoTematicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SistemasController : ControllerBase
    {
        private ISistemasService _sistemasService;

        public SistemasController(ISistemasService sistemasService)
        {
            this._sistemasService = sistemasService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Sistema>>> RecuperaSistemas()
        {
            try
            {
                var sistemas = await _sistemasService.RecuperaSistemas();
                if (sistemas.Count() == 0)
                    return NotFound($"NENHUM SISTEMA LOCALIZADO.");
                return Ok(sistemas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "NÃO FOI POSSÍVEL LOCALIZAR SISTEMAS.");
            }

        }

        [HttpGet("SistemaPorNome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Sistema>>> RecuperaSistemaPorNome([FromQuery] string nome)
        {
            try
            {
                var sistemas = await _sistemasService.RecuperaSistemaPorNome(nome);
                if (sistemas.Count() == 0)
                    return NotFound($"NENHUM SISTEMA LOCALIZADO COM O TERMO {nome}");
                return Ok(sistemas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "NÃO FOI POSSÍVEL LOCALIZAR SISTEMAS.");
            }
        }

        [HttpGet("{id:int}", Name = "RecuperaSistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Sistema>> RecuperaSistema(int id)
        {
            try
            {
                var sistema = await _sistemasService.RecuperaSistema(id);
                if (sistema == null)
                    return NotFound($"NÃO FOI POSSÍVEL LOCALIZAR O SISTEMA DE ID = {id}");
                return Ok(sistema);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "NÃO FOI POSSÍVEL LOCALIZAR O SISTEMA.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AdicionaSistema(Sistema sistema)
        {
            try
            {
                await _sistemasService.AdicionaSistema(sistema);
                return CreatedAtRoute(nameof(RecuperaSistema), new { id = sistema.Id }, sistema);
            }
            catch
            {
                return BadRequest("SOLICITAÇÃO INVÁLIDA");
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditaObra(int id, [FromBody] Sistema sistema)
        {
            try
            {
                if (sistema.Id == id)
                {
                    await _sistemasService.EditaSistema(sistema);
                    return Ok($"SISTEMA DE ID = {id} EDITADO COM SUCESSO.");
                }
                else
                {
                    return BadRequest("DADOS INCONSISTENTES.");
                }
            }
            catch
            {
                return BadRequest("SOLICITAÇÃO INVÁLIDA.");
            }
        }

        [HttpDelete ("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ExcluiSistema(int id)
        {
            try
            {
                var sistema = await _sistemasService.RecuperaSistema(id);
                if (sistema != null)
                {
                    await _sistemasService.ExcluiSistema(sistema);
                    return Ok($"SISTEMA DE ID = {id} EXCLUÍDO.");
                }
                else
                {
                    return NotFound($"SISTEMA DE ID = {id} NÃO LOCALIZADO.");
                }
            }
            catch
            {
                return BadRequest("SOLICITAÇÃO INVÁLIDA");
            }
        }
    }
}
