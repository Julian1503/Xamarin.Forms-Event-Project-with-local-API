using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Acreditacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Acreditacion
{
    public class AcreditacionServicio : IAcreditacionRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Acreditacion> _acreditacionRepositorio;

        DataContext _context;

        IMapper _mapper;

        public AcreditacionServicio(IRepositorio<Dominio.Entidades.Acreditacion> acreditacionRepositorio, DataContext context)
        {
            _acreditacionRepositorio = acreditacionRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

        }
        public async Task Delete(long entidadId)
        {
            using (var context = new DataContext())
            {
                var acreditacionBorrar = context.Acreditaciones.FirstOrDefault(x => x.Id == entidadId);


                await _acreditacionRepositorio.Delete(acreditacionBorrar);

            }
        }

        public async Task Insert(AcreditacionDto dto)
        {

            var nuevaAcreditacion = _mapper.Map<Dominio.Entidades.Acreditacion>(dto);

            await _acreditacionRepositorio.Create(nuevaAcreditacion);
        }

        public async Task Update(AcreditacionDto dto)
        {
            using (var context = new DataContext())
            {
                var modificarAcreditacion = context.Acreditaciones.FirstOrDefault(x => x.Id == dto.Id);

                modificarAcreditacion.PersonaId = dto.PersonaId;

                modificarAcreditacion.ProgramacionId = dto.ProgramacionId;

                modificarAcreditacion.Fecha = dto.Fecha;

                await _acreditacionRepositorio.Update(modificarAcreditacion);



            }
        }

    }
}
