namespace Comunidad.Dominio.Entidades
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class Evento : EntityBase
    {
        public long TipoEventoId { get; set; }

        public long TemaEventoId { get; set; }
        
        public string Nombre { get; set; }
               
        public Ubicacion Ubicacion { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }

        public string Descripcion { get; set; }

        public string Organizador { get; set; }

        public bool EsPaginaPublica { get; set; }

        public bool MostrarLasEntradasRestantes { get; set; }

        // Propiedades de Navegacion

        public virtual ICollection<Acreditacion> Acreditaciones { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }

        public virtual ICollection<Entrada> Entradas { get; set; }

        public virtual ICollection<Programacion> Programaciones { get; set; }

        public virtual TipoEvento TipoEvento { get; set; }

        public virtual TemaEvento TemaEvento { get; set; }      
    }
}
