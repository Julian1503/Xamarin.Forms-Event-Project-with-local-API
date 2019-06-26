using AutoMapper;
using Comunidad.Dominio.Extension;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Persona;
using Comunidad.Interfaces.Persona.DTOs;
using Comunidad.Interfaces.Ubicacion.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Persona> _personaRepositorio;

        private readonly IMapper _mapper;

        public PersonaRepositorio(IRepositorio<Dominio.Entidades.Persona> personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

        }

      

        public async Task<PersonaDto> GetById(long Id)
        {
            var persona = await _personaRepositorio.GetById(Id, include: x => x.Include(navigationPropertyPath: us => us.Usuario), true);

            if (persona == null)
            {
                return null;
            }
            else
            {
                var personaEncontrada = _mapper.Map<PersonaDto>(persona);


                return personaEncontrada;
            }
        }

        

        public async Task Insertar(PersonaDto dto)
        {
            var nuevaPersona = new Dominio.Entidades.Persona
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Celular = dto.Celular,
                ApellidoCasada = dto.ApellidoCasada,
                Dni = dto.Dni,
                Email = dto.Email,
                EstaBorrado = false,
                AltaPorMostrador = false,
                Telefono = dto.Telefono,
                Ubicacion = new Dominio.Entidades.Ubicacion
                {

                    Ciudad = dto.Ubicacion.Ciudad,
                    CodigoPostal = dto.Ubicacion.CodigoPostal,
                    Direccion = dto.Ubicacion.Direccion,
                    PaisId = dto.Ubicacion.PaisId,
                    Provincia = dto.Ubicacion.Provincia,
                    Id = dto.Ubicacion.Id



                } };


            await _personaRepositorio.Create(nuevaPersona);
 
        }


    }
}
