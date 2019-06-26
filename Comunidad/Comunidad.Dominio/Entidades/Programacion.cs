namespace Comunidad.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Programacion : EntityBase
    {
        public long EventoId { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSalida { get; set; }

        // Propiedades de Navegacion
        public virtual Evento Evento { get; set; }

        public virtual ICollection<Acreditacion> Acreditaciones { get; set; }
    }
}
