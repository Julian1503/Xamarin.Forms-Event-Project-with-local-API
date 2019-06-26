using Comunidad.Interfaces.Entrada.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Entrada
{
    public interface IEntradaRepositorio
    {
        Task Insertar(EntradaDto dto);

        Task<int> RestarEntradas(long entradaId);

    }
}
