namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class TemaEventoMetaData : IEntityTypeConfiguration<TemaEvento>
    {
        public void Configure(EntityTypeBuilder<TemaEvento> builder)
        {
            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .HasField("_descripcion")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);

            builder.HasData(Seed());
        }

        private List<TemaEvento> Seed()
        {
            var _listaTemas = new List<TemaEvento>
            {
                new TemaEvento{ Id = 1,EstaBorrado = false  ,Descripcion = "Concierto o performance"},
                new TemaEvento{ Id = 2,EstaBorrado = false  ,Descripcion = "Campamento o Retiro" },
                new TemaEvento{ Id = 3,EstaBorrado = false  ,Descripcion = "Carrera o Evento Deportivo" },
                new TemaEvento{ Id = 4,EstaBorrado = false  ,Descripcion = "Conferencia" },
                new TemaEvento{ Id = 5,EstaBorrado = false  ,Descripcion = "Convencion" },
                new TemaEvento{ Id = 6,EstaBorrado = false  ,Descripcion = "Festival o Feria" },
                new TemaEvento{ Id = 7,EstaBorrado = false  ,Descripcion = "Fiesta o Reunion social" },
                new TemaEvento{ Id = 8,EstaBorrado = false  ,Descripcion = "Tv Show" },
                new TemaEvento{ Id = 9,EstaBorrado = false  ,Descripcion = "Seminario o Charla" },
                new TemaEvento{ Id = 10,EstaBorrado = false  ,Descripcion = "Otros"}
            };

            return _listaTemas;

        }
    }
}
