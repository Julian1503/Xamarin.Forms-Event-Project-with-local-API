using ApiEvento.AutoMapperModelos;
using ApiEvento.Models.InscripcionModel;
using AutoMapper;
using Comunidad.Interfaces.Entrada;
using Comunidad.Interfaces.Inscripcion;
using Comunidad.Interfaces.Inscripcion.DTOs;
using Comunidad.Interfaces.Persona;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiEvento.Controllers.InscripcionController
{

    [ApiController]
        [Route("api/[controller]")]
        public class InscripcionController : ControllerBase
        {
            private readonly IInscripcionRepositorio _inscripcionRepos;

            private readonly IEntradaRepositorio _entradaRepositorio;

            private readonly IPersonaRepositorio _personaRepositorio;

            private readonly IMapper _mapper;

            public InscripcionController(IInscripcionRepositorio inscripcionRepos, IEntradaRepositorio entradaRepositorio,
                IPersonaRepositorio personaRepositorio)
            {
                _inscripcionRepos = inscripcionRepos;

                _entradaRepositorio = entradaRepositorio;

                var config = new MapperConfiguration(cfg => cfg.AddProfile<PerfilCreationDto>());

                _mapper = config.CreateMapper();

               _personaRepositorio = personaRepositorio;

            }


            [HttpPost]
            [EnableCors("_myPolicy")]
            [Route("crear")]

            public async Task<IActionResult> InsertarInscripcion(InscripcionCreationDto inscripcion)
            {
                var inscripcionDto = _mapper.Map<InscripcionDto>(inscripcion);

                await _inscripcionRepos.Insertar(inscripcionDto);

                await _entradaRepositorio.RestarEntradas(inscripcionDto.EntradaId);



                return Ok(true);
            }

        }
    }
