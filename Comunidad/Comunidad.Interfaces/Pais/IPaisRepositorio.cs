using Comunidad.Interfaces.Pais.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Pais
{
    public interface IPaisRepositorio
    {
         
        Task<IEnumerable<PaisDto>> ObtenerPaises(string cadenaBuscar);

        Task<IEnumerable<PaisDto>> ObtenerTodos();


    }
}
