namespace Comunidad.Dominio
{
    using System.ComponentModel.DataAnnotations;

    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        // Campo para Borrado Logico o Suave
        [Required]        
        public bool EstaBorrado { get; set; }

        // Campo para Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
