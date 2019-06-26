namespace Comunidad.Implementacion.TipoEvento
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using Comunidad.Dominio.Extension;
    using Comunidad.Dominio.Repositorio;
    using Comunidad.Infraestructura;
    using Comunidad.Interfaces.TipoEvento;
    using Comunidad.Interfaces.TipoEvento.DTOs;
    using Microsoft.EntityFrameworkCore;

    public class TipoEventoServicio : ITipoEventoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.TipoEvento> _tipoEventoRepository;

        private readonly IMapper _mapper;

      
        public TipoEventoServicio(IRepositorio<Dominio.Entidades.TipoEvento> tipoEventoRepository)
        {
            this._tipoEventoRepository = tipoEventoRepository;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

        }

        public async Task Create(TipoEventoDto dto)
        {
            var crearTipoEvento = new Dominio.Entidades.TipoEvento
            {
                Id = dto.Id,
                Descripcion = dto.Descripcion,
                EstaBorrado = false

            };

            await _tipoEventoRepository.Create(crearTipoEvento);
        }

   

        public async Task<IEnumerable<TipoEventoDto>> Obtener(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.TipoEvento, bool>> pred = x => true;
 
            pred = pred.And(x => x.Descripcion.Contains(cadenaBuscar));

            var tipoEventos = await _tipoEventoRepository.GetByFilter(pred, null, null);

            return tipoEventos
                .Select(x => new TipoEventoDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EstaBorrado = x.EstaBorrado
                }).ToList();
        }

        public async Task<TipoEventoDto> ObtenerPorId(long entidadId)
        {
            var tipoEvento = await _tipoEventoRepository.GetById(entidadId, null, true);

            if (tipoEvento == null)
            {
                return null;
            }
            else
            {
                var eventoEncontrado = _mapper.Map<TipoEventoDto>(tipoEvento);

                return eventoEncontrado;
            }
        }

        public async Task<IEnumerable<TipoEventoDto>> ObtenerTodos()
        {
            var tipoEventos = await _tipoEventoRepository
               .GetAll(null,null,false);

            return tipoEventos.Select(x => new TipoEventoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EstaBorrado = x.EstaBorrado
            
            });
        }

    
    }
}
