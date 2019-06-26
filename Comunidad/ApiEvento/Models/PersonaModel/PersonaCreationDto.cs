using Comunidad.Interfaces.Ubicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvento.Models.PersonaCreationDto
{
    public class PersonaCreationDto
    {

        public string Apellido { get; set; }

        public string ApellidoCasada { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public UbicacionDto Ubicacion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }
         
        public string Email { get; set; }

        public bool AltaPorMostrador { get; set; }



    }
}
