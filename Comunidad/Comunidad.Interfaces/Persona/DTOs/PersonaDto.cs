using Comunidad.Dominio.Entidades;
using Comunidad.Interfaces.Base;
using Comunidad.Interfaces.Ubicacion.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comunidad.Interfaces.Persona.DTOs
{
    public class PersonaDto : DtoBase
    {
        public string Apellido { get; set; }
         
        public string ApellidoCasada { get; set; }
        
        public string Nombre { get; set; }
         
        public string Dni { get; set; }

        public UbicacionDto Ubicacion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        //[DataType(DataType.EmailAddress,ErrorMessage ="El formato de Email es inválido")]
        //[Required(ErrorMessage ="Debe Ingresar un Email")]
        public string Email { get; set; }

        public bool AltaPorMostrador { get; set; }



    }
}
