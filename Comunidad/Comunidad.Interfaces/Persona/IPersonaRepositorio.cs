using Comunidad.Interfaces.Persona.DTOs;
using Comunidad.Interfaces.Usuario.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Persona
{
    public interface IPersonaRepositorio
    {
        Task Insertar(PersonaDto dto);


        Task <PersonaDto> GetById(long Id);

         
        

    }
}
