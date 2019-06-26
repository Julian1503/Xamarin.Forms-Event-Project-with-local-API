using Comunidad.Interfaces.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvento.Models.UsuarioModel
{
    public class UsuarioCreationDto
    {
        public string Usuario { get; set; }

        public string Password { get; set; }

        public PersonaDto Persona { get; set; }
 

    }
}
