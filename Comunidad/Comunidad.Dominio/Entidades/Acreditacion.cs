namespace Comunidad.Dominio.Entidades
{
    using System;

    public class Acreditacion : EntityBase
    {
        public long PersonaId { get; set; }

        public long ProgramacionId { get; set; }

        public DateTime Fecha { get; set; }

        // Propiedades de Navegacion
        public virtual Persona Persona { get; set; }

        public virtual Programacion Programacion { get; set; }
    }
}
