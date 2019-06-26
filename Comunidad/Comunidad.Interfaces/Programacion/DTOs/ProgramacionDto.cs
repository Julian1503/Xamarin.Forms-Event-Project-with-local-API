using Comunidad.Interfaces.Base;
using Comunidad.Interfaces.Evento.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Programacion.DTOs
{
    public class ProgramacionDto : DtoBase
    {
        public long EventoId { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSalida { get; set; }


    }
}
