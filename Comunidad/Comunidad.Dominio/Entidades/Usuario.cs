using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Dominio.Entidades
{
    
    public class Usuario:EntityBase
    {
        public long PersonaId { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }


        public virtual Persona Persona { get; set; }

    }
}
