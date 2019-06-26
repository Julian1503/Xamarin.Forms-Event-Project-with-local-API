using Comunidad.Interfaces.Entrada.DTOs;
using Comunidad.Interfaces.Programacion.DTOs;
using Comunidad.Interfaces.Ubicacion.DTOs;
using System.Collections.Generic;

namespace ApiEvento.Models.EventoModel
{
    public class EventoCreationDto
    {   
        public long Id { get; set; }

        public long TipoEventoId { get; set; }

        public long TemaEventoId { get; set; }

        public string Nombre { get; set; }

        public UbicacionDto Ubicacion { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }

        public string Descripcion { get; set; }

        public string Organizador { get; set; }

        public bool EsPaginaPublica { get; set; }

        public bool MostrarLasEntradasRestantes { get; set; }

        public ProgramacionDto Programacion { get; set; }

        public EntradaDto Entrada { get; set; }


    }
}
