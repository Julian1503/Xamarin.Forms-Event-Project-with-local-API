using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Evento;
using Comunidad.Interfaces.Evento.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Comunidad.Dominio.Extension;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Comunidad.Interfaces.Ubicacion.DTOs;
using Comunidad.Interfaces.Entrada;
using Comunidad.Interfaces.Programacion;
using System.Transactions;
using Comunidad.Interfaces.Programacion.DTOs;
using Comunidad.Interfaces.Entrada.DTOs;

namespace Comunidad.Implementacion.Evento
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Evento> _eventoRepositorio;

        private readonly IEntradaRepositorio _entradaRepositorio;

        private readonly IProgramacionRepositorio _programacionRepositorio;

        private readonly IMapper _mapper;

        DataContext _context;
         
        public EventoRepositorio(IRepositorio<Dominio.Entidades.Evento> eventoRepositorio, DataContext context)
        {
            _eventoRepositorio = eventoRepositorio;

             

            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();
        }



      
    

        public async  Task<EventoDto> ObtenerPorId(long eventoId)
        {
           

            var evento = await  _eventoRepositorio.GetById(eventoId, include: x => x.Include(navigationPropertyPath: ub => ub.Ubicacion)
            .Include(l => l.Programaciones).Include(p => p.Entradas), true);

            if (evento == null)
            {
                return null;
            }
            else
            {
                //var eventoEncontrado = _mapper.Map<EventoDto>(evento);

                //return eventoEncontrado;

                return new EventoDto
                {
                    Id = evento.Id,
                    Descripcion = evento.Descripcion,
                    EsPaginaPublica = evento.EsPaginaPublica,
                    EstaBorrado = false,
                    FileName = evento.FileName,
                    MostrarLasEntradasRestantes = evento.MostrarLasEntradasRestantes,
                    Organizador = evento.Organizador,
                    Nombre = evento.Nombre,
                    TemaEventoId = evento.TemaEventoId,
                    TipoEventoId = evento.TipoEventoId,
                    Path = evento.Path,
                    Ubicacion = new UbicacionDto
                    {
                        Ciudad = evento.Ubicacion.Ciudad,
                        CodigoPostal = evento.Ubicacion.CodigoPostal,
                        Direccion = evento.Ubicacion.Direccion,
                        PaisId = evento.Ubicacion.PaisId,
                        Provincia = evento.Ubicacion.Provincia

                    },
                    Programacion = new ProgramacionDto
                    {
                        Id = evento.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).Id,
                        FechaDesde = evento.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaDesde,
                        FechaHasta = evento.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaHasta,
                        HoraEntrada = evento.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraEntrada,
                        HoraSalida = evento.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraSalida
                    },
                    Entrada = new EntradaDto
                    {
                        Id = evento.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Id,
                        CantidadDisponible = evento.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).CantidadDisponible,
                        Nombre = evento.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Nombre,
                        Precio = evento.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Precio,
                        TipoEntrada = evento.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).TipoEntrada,

                    }
                };

            }

         

        }

        public async Task Insertar(EventoDto dto)
        {

            var nuevoEvento = new Dominio.Entidades.Evento
            {
                Descripcion = dto.Descripcion,
                EsPaginaPublica = dto.EsPaginaPublica,
                EstaBorrado = false,
                FileName = dto.FileName,
                MostrarLasEntradasRestantes = dto.MostrarLasEntradasRestantes,
                Organizador = dto.Organizador,
                Nombre = dto.Nombre,
                TemaEventoId = dto.TemaEventoId,
                TipoEventoId = dto.TipoEventoId,
                Path = dto.Path,
                Ubicacion = new Dominio.Entidades.Ubicacion
                {
                    Ciudad = dto.Ubicacion.Ciudad,
                    CodigoPostal = dto.Ubicacion.CodigoPostal,
                    Direccion = dto.Ubicacion.Direccion,
                    PaisId = dto.Ubicacion.PaisId,
                    Provincia = dto.Ubicacion.Provincia

                },
                Programaciones = new List<Dominio.Entidades.Programacion>
                    {
                    new Dominio.Entidades.Programacion
                    {
                      EstaBorrado = false,
                      EventoId = dto.Id,
                      FechaDesde = dto.Programacion.FechaDesde,
                      FechaHasta = dto.Programacion.FechaHasta,
                      HoraEntrada = dto.Programacion.HoraEntrada,
                      HoraSalida = dto.Programacion.HoraSalida

                    }


                },
                Entradas = new List<Dominio.Entidades.Entrada>
                {
                    new Dominio.Entidades.Entrada
                    {
                      CantidadDisponible = dto.Entrada.CantidadDisponible,
                      EventoId = dto.Id,
                      EstaBorrado = dto.Entrada.EstaBorrado,
                      Nombre = dto.Entrada.Nombre,
                      Precio = dto.Entrada.Precio,
                      TipoEntrada = dto.Entrada.TipoEntrada
                    }


                }
            };


            using (var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _eventoRepositorio.Create(nuevoEvento);
                scoped.Complete();
                scoped.Dispose();
            }




        }

        public async Task<IEnumerable<EventoDto>> Obtener(string cadenaBuscar)
        {
            var eventos = await _eventoRepositorio
                .GetByFilter(x => x.Descripcion.Contains(cadenaBuscar),
                    null, include: x => x.Include(navigationPropertyPath: s => s.Ubicacion).Include(e => e.Entradas)
                    .Include(l => l.Programaciones)
                    , true);

            return eventos.Select(x => new EventoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EsPaginaPublica = x.EsPaginaPublica,
                EstaBorrado = false,
                FileName = x.FileName,
                MostrarLasEntradasRestantes = x.MostrarLasEntradasRestantes,
                Organizador = x.Organizador,
                Nombre = x.Nombre,
                TemaEventoId = x.TemaEventoId,
                TipoEventoId = x.TipoEventoId,
                Path = x.Path,
                Ubicacion = new UbicacionDto
                {
                    Ciudad = x.Ubicacion.Ciudad,
                    CodigoPostal = x.Ubicacion.CodigoPostal,
                    Direccion = x.Ubicacion.Direccion,
                    PaisId = x.Ubicacion.PaisId,
                    Provincia = x.Ubicacion.Provincia

                },
                Programacion = new ProgramacionDto
                {
                    Id = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).Id,
                    FechaDesde = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaDesde,
                    FechaHasta = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaHasta,
                    HoraEntrada = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraEntrada,
                    HoraSalida = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraSalida
                },
                Entrada = new EntradaDto
                {
                    Id = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Id,
                    CantidadDisponible = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).CantidadDisponible,
                    Nombre = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Nombre,
                    Precio = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Precio,
                    TipoEntrada = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).TipoEntrada,

                }
            }).ToList();


        }



        public async Task<IEnumerable<EventoDto>> ObtenerTodos()
        {


            var eventos = await _eventoRepositorio.GetAll(null, include: x => x.Include(navigationPropertyPath: ub => ub.Ubicacion)
         .Include(l => l.Programaciones).Include(p => p.Entradas), true);

            //var evenT = _mapper.Map<IEnumerable<Dominio.Entidades.Evento>, IEnumerable<EventoDto>>(eventos);

            //return evenT;

            return eventos.Select(x => new EventoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EsPaginaPublica = x.EsPaginaPublica,
                EstaBorrado = false,
                FileName = x.FileName,
                MostrarLasEntradasRestantes = x.MostrarLasEntradasRestantes,
                Organizador = x.Organizador,
                Nombre = x.Nombre,
                TemaEventoId = x.TemaEventoId,
                TipoEventoId = x.TipoEventoId,
                Path = x.Path,
                Ubicacion = new UbicacionDto
                {
                    Ciudad = x.Ubicacion.Ciudad,
                    CodigoPostal = x.Ubicacion.CodigoPostal,
                    Direccion = x.Ubicacion.Direccion,
                    PaisId = x.Ubicacion.PaisId,
                    Provincia = x.Ubicacion.Provincia

                },
                Programacion = new ProgramacionDto
                {
                    Id = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).Id,
                    FechaDesde = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaDesde,
                    FechaHasta = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).FechaHasta,
                    HoraEntrada = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraEntrada,
                    HoraSalida = x.Programaciones.FirstOrDefault(l => l.EventoId == l.Evento.Id).HoraSalida
                },
                Entrada = new EntradaDto
                {
                    Id = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Id,
                    CantidadDisponible = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).CantidadDisponible,
                    Nombre = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Nombre,
                    Precio = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).Precio,
                    TipoEntrada = x.Entradas.FirstOrDefault(p => p.EventoId == p.Evento.Id).TipoEntrada,

                }
            });





        }
    }

}
