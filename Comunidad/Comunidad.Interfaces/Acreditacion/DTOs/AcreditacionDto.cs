using Comunidad.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Acreditacion.DTOs
{
    public class AcreditacionDto : DtoBase
    {
        public long PersonaId { get; set; }

        public long ProgramacionId { get; set; }

        public DateTime Fecha { get; set; }

    }
}
