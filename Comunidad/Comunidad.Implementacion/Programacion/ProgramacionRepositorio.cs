using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Programacion;
using Comunidad.Interfaces.Programacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Programacion
{
    public class ProgramacionRepositorio : IProgramacionRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Programacion> _programacionRepositorio;

        private readonly IMapper _mapper;

        private DataContext _context;
        public ProgramacionRepositorio(IRepositorio<Dominio.Entidades.Programacion> programacionRepositorio, DataContext context)
        {
            _programacionRepositorio = programacionRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

            _context = context;

        }


 

        public async Task Insertar(ProgramacionDto dto)
        {
            var nuevaProgramacion = _mapper.Map<Dominio.Entidades.Programacion>(dto);
             
            await _programacionRepositorio.Create(nuevaProgramacion);
        }

    
    }
}
