namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    public class EventoMetaData : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.Property(x => x.TemaEventoId).IsRequired();

            builder.Property(x => x.TipoEventoId).IsRequired();

            builder.Property(x => x.Nombre)
                .HasMaxLength(400)
                .IsRequired();

            builder.OwnsOne(x => x.Ubicacion, dir =>
            {
                dir.Property(x => x.Direccion).HasColumnName("Direccion");

                dir.Property(x => x.Ciudad).HasColumnName("Ciudad");

                dir.Property(x => x.Provincia).HasColumnName("Provincia");

                dir.Property(x => x.CodigoPostal).HasColumnName("CodigoPostal");

                dir.Property(x => x.PaisId).HasColumnName("PaisId");
            });

            builder.Property(x => x.FileName)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(x => x.Path)
                .HasMaxLength(400)
                .IsRequired(false);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.Organizador)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.EsPaginaPublica)
                .HasColumnType<bool>("bit")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.MostrarLasEntradasRestantes)
                .HasColumnType<bool>("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
