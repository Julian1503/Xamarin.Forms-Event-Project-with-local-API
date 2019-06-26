using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidad.Interfaces.Pais;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvento.Controllers.PaisController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepositorio _paisRepositorio;


        public PaisController(IPaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }
        

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerPaises()
        {
            try
            {
                var Paises = await _paisRepositorio.ObtenerTodos();
                return Ok(Paises);
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

    }
}