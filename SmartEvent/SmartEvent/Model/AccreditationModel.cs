using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEvent.Model
{
    public class AccreditationModel: ModelBase
    {
        public long PersonaId { get; set; }
        public long ProgramacionId { get; set; }
        public DateTime Fecha { get; set; }
        public long EventoId { get; set; }
    }
}
