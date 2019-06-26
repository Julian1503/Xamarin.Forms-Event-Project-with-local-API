using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Entrada;
using Comunidad.Interfaces.Entrada.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Entrada
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Entrada> _entradaRepositorio;

        DataContext _context;

        IMapper _mapper;
        public EntradaRepositorio(IRepositorio<Dominio.Entidades.Entrada> entradaRepositorio, DataContext context)
        {

            _entradaRepositorio = entradaRepositorio;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();

            _context = context;

        }

        public async Task Delete(long entidadId)
        {
            using (var context = new DataContext())
            {
                var borrarEntrada = context.Entradas.FirstOrDefault(x => x.Id == entidadId);

                await _entradaRepositorio.Delete(borrarEntrada);

            }
        }

        public async Task Insertar(EntradaDto dto)
        { 
            var nuevaEntrada = _mapper.Map<Dominio.Entidades.Entrada>(dto);

            await _entradaRepositorio.Create(nuevaEntrada);

        }

        public async Task<int> RestarEntradas(long entradaId)
        {
            var modificarEntrada = _context.Entradas.FirstOrDefault(x => x.Id == entradaId);

            bool resultado = await Task.Run(() =>
            {
                if (modificarEntrada.CantidadDisponible == 0)
                {
                    return false;
                }

                modificarEntrada.CantidadDisponible = modificarEntrada.CantidadDisponible - 1;
                _entradaRepositorio.Update(modificarEntrada);
                  return true;
               
            });


            return modificarEntrada.CantidadDisponible;




        }

        public async Task Update(EntradaDto dto)
        {
            using (var context = new DataContext())
            {
                var modificarEntradas = context.Entradas.FirstOrDefault(x => x.Id == dto.Id);

                modificarEntradas.Nombre = dto.Nombre;
                modificarEntradas.Precio = dto.Precio;
               
                modificarEntradas.CantidadDisponible = dto.CantidadDisponible;
                modificarEntradas.TipoEntrada = dto.TipoEntrada;

                await _entradaRepositorio.Update(modificarEntradas);
            }




        }


    }
}
