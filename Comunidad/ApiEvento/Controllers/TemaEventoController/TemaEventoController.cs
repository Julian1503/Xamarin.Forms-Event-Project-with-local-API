using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidad.Interfaces.TemaEvento;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvento.Controllers.TemaEventoController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemaEventoController : ControllerBase
    {
        private readonly ITemaEventoServicio _temaEventoRepos;
        public TemaEventoController(ITemaEventoServicio temaEventoRepos)
        {
            _temaEventoRepos = temaEventoRepos;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerTemaEvento()
        {
            try
            {
                var listaTemas = await _temaEventoRepos.ObtenerTodos();
                return Ok(listaTemas);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerPorId(long id)
        {
            try
            {
                var temaEventoPorId = await _temaEventoRepos.ObtenerPorId(id);
                return Ok(temaEventoPorId);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound("No se encontró el tema del Evento");
            }






        }


    }
}