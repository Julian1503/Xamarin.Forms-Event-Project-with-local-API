using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Pais;
using Comunidad.Interfaces.Pais.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Pais
{
    public class PaisServicio : IPaisRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Pais> _paisRepositorio;

        private IMapper _mapper; 
        public PaisServicio(IRepositorio<Dominio.Entidades.Pais> paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

        }

 
 

        public async Task<IEnumerable<PaisDto>> ObtenerPaises(string cadenaBuscar)
        {
            var paises  = await _paisRepositorio
                .GetByFilter(x => x.Descripcion.Contains(cadenaBuscar),null, null);

            var paiseslista = _mapper.Map<IEnumerable<Dominio.Entidades.Pais>,IEnumerable<PaisDto>>(paises);

            return paiseslista;
        }

        public async Task<IEnumerable<PaisDto>> ObtenerTodos()
        {
            var paises = await _paisRepositorio
               .GetAll(null,null,false);

            var paiseslista = _mapper.Map<IEnumerable<Dominio.Entidades.Pais>, IEnumerable<PaisDto>>(paises);

            return paiseslista;
        }

 
    }
}
