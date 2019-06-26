using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Acreditacion.DTOs
{
    public interface IAcreditacionRepositorio
    {
        Task Insert(AcreditacionDto dto);

    }
}
