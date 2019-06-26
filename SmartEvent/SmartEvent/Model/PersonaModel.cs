using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEvent.Model
{
    public class PersonaModel : ModelBase
    {
        public string Apellido { get; set; }
        public string ApellidoCasada { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public UbicationModel Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool AltaPorMostrador { get; set; }
    }
}
