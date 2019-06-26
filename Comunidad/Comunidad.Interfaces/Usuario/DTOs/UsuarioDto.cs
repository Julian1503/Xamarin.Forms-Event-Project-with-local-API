using Comunidad.Interfaces.Base;
using Comunidad.Interfaces.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Usuario.DTOs
{
    public class UsuarioDto:DtoBase
    {
        public PersonaDto Persona { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }
  

    }
}
