namespace Comunidad.Dominio.Entidades
{    
    using System;
    using System.Collections.Generic;

    using Comunidad.Constantes;
    public class Inscripcion : EntityBase
    {
 
        public long EntradaId { get; set; }

        public long PersonaId { get; set; }
         
        public DateTime Fecha { get; set; }

        public EstadoInscripcion EstadoInscripcion { get; set; }

        // Propiedades de Navegacion
        public virtual Entrada Entrada { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Ocupacion Ocupacion { get; set; }

   
    }
}
