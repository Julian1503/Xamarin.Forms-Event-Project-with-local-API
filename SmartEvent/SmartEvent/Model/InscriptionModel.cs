using System;

namespace SmartEvent.Model
{
    public class InscriptionModel : ModelBase
    {
        public long EntradaId { get; set; }
        public long PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoInscripcion EstadoInscripcion { get; set; }


    }
    public enum EstadoInscripcion
    {
        Aprobada = 1,
        Pendiente = 2,
        Cancelada = 3
    }

}
