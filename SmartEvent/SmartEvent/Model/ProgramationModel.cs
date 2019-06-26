using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEvent.Model
{
    public class ProgramationModel : ModelBase
    {
      
            public long EventoId { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public string HoraEntrada { get; set; }
            public string HoraSalida { get; set; }

    }
}
