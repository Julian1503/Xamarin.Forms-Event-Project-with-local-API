namespace Comunidad.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Persona : EntityBase
    {
        private string _apellido;
        private string _apellidoCasada;
        private string _nombre;

        public Usuario Usuario { get; set; }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            }
        }

        public string ApellidoCasada
        {
            get { return _apellidoCasada; }
            set
            {
                _apellidoCasada = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            }
        }

        public string Dni { get; set; }

        public Ubicacion Ubicacion { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool AltaPorMostrador { get; set; }
        
        
        // Propiedades de Navegacion
        public virtual ICollection<Acreditacion> Acreditaciones { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
 
    }
}