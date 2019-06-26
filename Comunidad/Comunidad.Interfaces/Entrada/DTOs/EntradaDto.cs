using Comunidad.Constantes;
using Comunidad.Interfaces.Base;
using Comunidad.Interfaces.Evento.DTOs;
using Comunidad.Interfaces.Programacion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Entrada.DTOs
{
    public class EntradaDto : DtoBase
    {
        
        public long EventoId { get; set; }

        public string Nombre { get; set; }

        public int CantidadDisponible { get; set; }

        public decimal Precio { get; set; }

        public TipoEntrada TipoEntrada { get; set; }

        //public EventoDto Evento { get; set; }

        


    }
}
