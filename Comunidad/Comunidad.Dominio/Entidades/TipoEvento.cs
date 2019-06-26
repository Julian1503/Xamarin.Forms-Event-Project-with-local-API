using System.Collections.Generic;
using System.Linq;

namespace Comunidad.Dominio.Entidades
{
    public class TipoEvento : EntityBase
    {
        private string _descripcion;

        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
