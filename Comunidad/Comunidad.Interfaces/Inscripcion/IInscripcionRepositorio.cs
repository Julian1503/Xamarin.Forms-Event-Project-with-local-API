using Comunidad.Interfaces.Inscripcion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Inscripcion
{
    public interface IInscripcionRepositorio
    {
        Task Insertar(InscripcionDto dto);

   

    }

}
