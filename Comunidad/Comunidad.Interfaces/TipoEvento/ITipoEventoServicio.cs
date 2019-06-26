namespace Comunidad.Interfaces.TipoEvento
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Comunidad.Interfaces.TipoEvento.DTOs;

    public interface ITipoEventoServicio
    {
        Task<IEnumerable<TipoEventoDto>> Obtener(string cadenaBuscar);

        Task<TipoEventoDto> ObtenerPorId(long entidadId);

        Task<IEnumerable<TipoEventoDto>> ObtenerTodos();

        
    }
}
