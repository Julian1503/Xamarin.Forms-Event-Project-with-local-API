namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class TipoEventoMetaData : IEntityTypeConfiguration<TipoEvento>
    {
        public void Configure(EntityTypeBuilder<TipoEvento> builder)
        {
          
            builder.HasData(Seed());

            builder.Property(x => x.Descripcion)
              .HasMaxLength(250)
              .IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);

        }

        private List<TipoEvento> Seed()
        {
            var _listaTipoEvento = new List<TipoEvento>
            {

               new TipoEvento{Id = 1, Descripcion = "Hogar y estilo de vida"},
               new TipoEvento{Id = 2, Descripcion = "Artes escenicas y visuales"},
               new TipoEvento{Id = 3, Descripcion = "Cine medios de comunicacion y entretenimiento"},
               new TipoEvento{Id = 4, Descripcion = "Deportes y salud"},
               new TipoEvento{Id = 5, Descripcion = "Dias de fiesta"},
               new TipoEvento{Id = 6, Descripcion = "Familias y educacion"},
               new TipoEvento{Id = 7, Descripcion = "Gastronomia"},
               new TipoEvento{Id = 8, Descripcion = "Política"},
               new TipoEvento{Id = 9, Descripcion = "Moda y belleza "},
               new TipoEvento{Id = 10,Descripcion = "Otros"}
            };

            return _listaTipoEvento;


           
        }
    }
}
