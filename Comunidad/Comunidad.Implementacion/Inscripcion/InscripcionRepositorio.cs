using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Inscripcion;
using Comunidad.Interfaces.Inscripcion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Inscripcion
{
    public class InscripcionRepositorio : IInscripcionRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Inscripcion> _inscripcionRepositorio;

 
        private  readonly IMapper _mapper;

        public InscripcionRepositorio(IRepositorio<Dominio.Entidades.Inscripcion> inscripcionRepositorio)
        {

            _inscripcionRepositorio = inscripcionRepositorio;

            

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

        }

 

        public async Task Insertar(InscripcionDto dto)
        {
            var nuevaInscripcion = _mapper.Map<Dominio.Entidades.Inscripcion>(dto);

            await _inscripcionRepositorio.Create(nuevaInscripcion);
        }

        
    }
}
