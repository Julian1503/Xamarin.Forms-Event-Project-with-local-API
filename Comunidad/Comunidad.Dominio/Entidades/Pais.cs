namespace Comunidad.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.Linq;

    public class Pais : EntityBase
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToUpper())
                    .ToArray());
            }
        }


    }
}
