namespace Comunidad.Dominio.Entidades
{
    using System.Collections.Generic;

    using Comunidad.Constantes;
    
    public class Entrada : EntityBase
    {
        public long EventoId { get; set; }

        public string Nombre { get; set; }

        public int CantidadDisponible { get; set; }

        public decimal Precio { get; set; }

        public TipoEntrada TipoEntrada { get; set; }

        // Propiedades de Navegacion
        public virtual Evento Evento { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
