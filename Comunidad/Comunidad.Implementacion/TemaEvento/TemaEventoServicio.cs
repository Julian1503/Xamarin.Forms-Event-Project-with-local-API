using System.Linq;
using Comunidad.Dominio.Repositorio;
 

namespace Comunidad.Implementacion.TemaEvento
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Comunidad.Infraestructura;
    using Comunidad.Infraestructura.Repositorio;
    using Comunidad.Interfaces.TemaEvento;
    using Comunidad.Interfaces.TemaEvento.DTOs;


    public class TemaEventoServicio : ITemaEventoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.TemaEvento> _temaEventoRepositorio;

        private readonly IMapper _mapper;

        public TemaEventoServicio(IRepositorio<Dominio.Entidades.TemaEvento> temaEventoRepositorio)
        {
            _temaEventoRepositorio = temaEventoRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

        }

        public async Task Insertar(TemaEventoDto dto)
        {
            var nuevaEntidad = new Dominio.Entidades.TemaEvento
            {
                Id = dto.Id,
                Descripcion = dto.Descripcion,
                EstaBorrado = false
            };

            await _temaEventoRepositorio.Create(nuevaEntidad);
        }

        

        public async Task<IEnumerable<TemaEventoDto>> Obtener(string cadenaBuscar)
        {
            var temasEventos = await _temaEventoRepositorio
                .GetByFilter(x => x.Descripcion.Contains(cadenaBuscar)
                    , null
                    , null);

            return temasEventos
                .Select(x => new TemaEventoDto
                {
                    Id = x.Id,
                    EstaBorrado = x.EstaBorrado,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public async Task<TemaEventoDto> ObtenerPorId(long entidadId)
        {
            var temaEvento = await _temaEventoRepositorio.GetById(entidadId, null, true);

            if (temaEvento == null)
            {
                return null;
            }
            else
            {
                var eventoEncontrado = _mapper.Map<TemaEventoDto>(temaEvento);

                return eventoEncontrado;
            }


        }

        public async Task<IEnumerable<TemaEventoDto>> ObtenerTodos()
        {
            var temaEventos = await _temaEventoRepositorio
               .GetAll(null,null,false);

            return temaEventos.Select(x => new TemaEventoDto
            {
                Descripcion = x.Descripcion,
                Id = x.Id
            });
        }

      

    }
}
