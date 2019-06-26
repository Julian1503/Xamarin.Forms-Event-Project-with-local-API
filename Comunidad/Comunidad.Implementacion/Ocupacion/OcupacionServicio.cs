using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Ocupacion;
using Comunidad.Interfaces.Ocupacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Ocupacion
{
    public class OcupacionServicio : IOcupacionServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Ocupacion> _ocupacionRepositorio;

        public OcupacionServicio(IRepositorio<Dominio.Entidades.Ocupacion> ocupacionRepositorio)
        {

            _ocupacionRepositorio = ocupacionRepositorio;

        }
       
        public async Task Insertar(OcupacionDto dto)
        {
            var nuevaOcupacion = new Dominio.Entidades.Ocupacion
            {
                Id = dto.Id,

                Descripcion = dto.Descripcion,

                EstaBorrado = false
            };

            await _ocupacionRepositorio.Create(nuevaOcupacion);
        }

         
    }
}
