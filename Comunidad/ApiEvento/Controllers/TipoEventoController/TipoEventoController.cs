using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidad.Interfaces.TipoEvento;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvento.Controllers.TipoEventoController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoServicio _tipoEventoRepos;



        public TipoEventoController(ITipoEventoServicio tipoEventoRepos)
        {
            _tipoEventoRepos = tipoEventoRepos;
        }


        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerTipoEvento()
        {
            try
            {
                var tipoEventos = await _tipoEventoRepos.ObtenerTodos();
                return Ok(tipoEventos);
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
                var tipoEventoId = await _tipoEventoRepos.ObtenerPorId(id);
                return Ok(tipoEventoId);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound("No se encontró el tema del Evento");
            }




        }



    }
}