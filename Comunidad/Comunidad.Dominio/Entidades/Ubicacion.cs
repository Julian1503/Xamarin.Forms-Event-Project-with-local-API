namespace Comunidad.Dominio.Entidades
{
    using Microsoft.EntityFrameworkCore;

    [Owned]
    public class Ubicacion 
    {
        public long Id { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        public long? PaisId { get; set; }

        // Propiedades de Navegacion
        
        public virtual Pais Pais { get; set; }
    }
}
