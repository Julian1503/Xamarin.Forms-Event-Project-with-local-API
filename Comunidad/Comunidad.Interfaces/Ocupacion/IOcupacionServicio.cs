using Comunidad.Dominio.Repositorio;
using Comunidad.Interfaces.Ocupacion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Ocupacion
{
    public interface IOcupacionServicio 
    {
        Task Insertar(OcupacionDto dto);
 
    }
}
