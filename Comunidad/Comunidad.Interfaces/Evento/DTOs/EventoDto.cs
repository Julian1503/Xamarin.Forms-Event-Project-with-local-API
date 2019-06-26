using Comunidad.Dominio.Entidades;
using Comunidad.Interfaces.Base;
using Comunidad.Interfaces.Entrada.DTOs;
using Comunidad.Interfaces.Programacion.DTOs;
using Comunidad.Interfaces.Ubicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Evento.DTOs
{
    public class EventoDto:DtoBase
    {
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

        public EntradaDto  Entrada { get; set; }


    }
}
