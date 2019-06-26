using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEvento.AutoMapperModelos;
using ApiEvento.Models.UsuarioModel;
using AutoMapper;
using Comunidad.Interfaces.Persona;
using Comunidad.Interfaces.Persona.DTOs;
using Comunidad.Interfaces.Ubicacion.DTOs;
using Comunidad.Interfaces.Usuario;
using Comunidad.Interfaces.Usuario.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEvento.Controllers.UsuarioController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly IPersonaRepositorio _personaRepositorio;

        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IPersonaRepositorio personaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

            _personaRepositorio = personaRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PerfilCreationDto>());

            _mapper = config.CreateMapper();
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("crear")]
        public async Task<IActionResult> CrearUsuario(UsuarioCreationDto dto)
        {
            if (await _usuarioRepositorio.VerificarSiExiste(dto.Usuario))
            {

                return Ok("El Usuario que está intentando crear ya existe");

            }


            var persona = _mapper.Map<PersonaDto>(dto.Persona);

            var nuevoUsuario = new UsuarioDto
            {
                Usuario = dto.Usuario,
                Password = dto.Password,
                Persona = persona
            };

            await _usuarioRepositorio.Crear(nuevoUsuario);
            return Ok(dto);



        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("login")]

        public async Task<IActionResult> Login(string nombreUsuario, string Contraseña)
        {
            bool ingreso = await _usuarioRepositorio.Login(nombreUsuario, Contraseña);

            return Ok(ingreso);

        }

 
        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getpersona-nombreusuario-o-dni")]
        public async Task<IActionResult> GetPersonaByUsuario(string nombreUsuario)
        {

            var persona = await _usuarioRepositorio.GetByUsuario(nombreUsuario);

            return Ok(persona);
        }
           

         

    }
}