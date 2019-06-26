using Comunidad.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvento.Models.InscripcionModel
{
    public class InscripcionCreationDto
    { 

        public long EntradaId { get; set; }

        public long PersonaId { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoInscripcion EstadoInscripcion { get; set; }

    }
}
