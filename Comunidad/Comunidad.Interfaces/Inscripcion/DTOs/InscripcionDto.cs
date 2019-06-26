using Comunidad.Constantes;
using Comunidad.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Inscripcion.DTOs
{
    public class InscripcionDto:DtoBase
    {
        
        public long EntradaId { get; set; }

        public long PersonaId { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoInscripcion EstadoInscripcion { get; set; }

    }
}
