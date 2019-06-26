namespace Comunidad.Interfaces.TemaEvento
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;

    public interface ITemaEventoServicio
    {
        Task<IEnumerable<TemaEventoDto>> Obtener(string cadenaBuscar);

        Task<TemaEventoDto> ObtenerPorId(long entidadId);

        Task<IEnumerable<TemaEventoDto>> ObtenerTodos();
 
 
    }
}
