using Comunidad.Interfaces.Evento.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Evento
{
    public interface IEventoRepositorio
    {
        Task<IEnumerable<EventoDto>> Obtener(string cadenaBuscar);

        Task<IEnumerable<EventoDto>> ObtenerTodos();

        Task <EventoDto> ObtenerPorId(long eventoId);

        Task Insertar(EventoDto dto);

   



    }
}
