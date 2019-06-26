using ApiEvento.AutoMapperModelos;
using ApiEvento.Models.EventoModel;
using AutoMapper;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Entrada;
using Comunidad.Interfaces.Entrada.DTOs;
using Comunidad.Interfaces.Evento;
using Comunidad.Interfaces.Evento.DTOs;
using Comunidad.Interfaces.Programacion;
using Comunidad.Interfaces.Programacion.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace ApiEvento.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepositorio _eventoRepos;

        private readonly IProgramacionRepositorio _programacionRepos;

        private readonly IEntradaRepositorio _entradaRepos;

        private readonly IMapper _mapper;

        private readonly DataContext _context;



        public EventoController(IEventoRepositorio eventoRepos, IProgramacionRepositorio programacionRepos
            , IEntradaRepositorio entradaRepos, DataContext context)
        {

            _eventoRepos = eventoRepos;

            _programacionRepos = programacionRepos;

            _entradaRepos = entradaRepos;

            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PerfilCreationDto>());

            _mapper = config.CreateMapper();


        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("crear")]

        public async Task<IActionResult> Insertar(EventoCreationDto dto)
        {
             var evento = new EventoDto
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
                    Ubicacion = new Comunidad.Interfaces.Ubicacion.DTOs.UbicacionDto
                    {
                        Ciudad = dto.Ubicacion.Ciudad,
                        CodigoPostal = dto.Ubicacion.CodigoPostal,
                        Direccion = dto.Ubicacion.Direccion,
                        PaisId = dto.Ubicacion.PaisId,
                        Provincia = dto.Ubicacion.Provincia
                    },
                    Programacion  = new ProgramacionDto
                        {
                        EstaBorrado = dto.Programacion.EstaBorrado,
                        EventoId = dto.Id,
                        FechaDesde = dto.Programacion.FechaDesde,
                        FechaHasta = dto.Programacion.FechaHasta,
                        HoraEntrada = dto.Programacion.HoraEntrada,
                        HoraSalida = dto.Programacion.HoraSalida
                         },
                    
                    Entrada =  new EntradaDto
                        {
                        CantidadDisponible = dto.Entrada.CantidadDisponible,
                        EventoId = dto.Id,
                        EstaBorrado = dto.Entrada.EstaBorrado,
                        Nombre = dto.Entrada.Nombre,
                        Precio = dto.Entrada.Precio,
                        TipoEntrada = dto.Entrada.TipoEntrada
                         }
                    
            };


                   await _eventoRepos.Insertar(evento);

                   
                   return Ok(dto);



        }
    







        


        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route ("obtenerpordescripcion")]
        public async Task<IActionResult> ObtenerEventos(string cadenaBuscar)
        {
           

            try
            {
                var evento = await _eventoRepos.Obtener(cadenaBuscar);
                return Ok(evento);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
     
       
        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("{id}", Name = "ObtenerEventoCreado")]

        public async Task <IActionResult> ObtenerPorId(long id)
        {
            
            try
            {
                var eventoPorId = await _eventoRepos.ObtenerPorId(id);
                return Ok(eventoPorId);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound("No se encontró el evento");
            }
          
        }



        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("obtenertodos")]
        public async Task<IActionResult> ObtenerTodosEventos()
        {
            try
            {
                var eventos = await _eventoRepos.ObtenerTodos();
                return Ok(eventos);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }







    }
}

