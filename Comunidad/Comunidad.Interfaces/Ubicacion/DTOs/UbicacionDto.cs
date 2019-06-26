using Comunidad.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Interfaces.Ubicacion.DTOs
{
    public class UbicacionDto
    {
        public long Id { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        public long? PaisId { get; set; }

    }
}
