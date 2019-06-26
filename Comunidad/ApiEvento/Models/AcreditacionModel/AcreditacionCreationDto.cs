using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvento.Models.AcreditacionModel
{
    public class AcreditacionCreationDto
    {
        public long PersonaId { get; set; }

        public long ProgramacionId { get; set; }

        public DateTime Fecha { get; set; }

    }
}
