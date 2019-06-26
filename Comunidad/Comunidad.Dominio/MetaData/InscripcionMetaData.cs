namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InscripcionMetaData : IEntityTypeConfiguration<Inscripcion>
    {
        public void Configure(EntityTypeBuilder<Inscripcion> builder)
        {
            builder.Property(x => x.EntradaId).IsRequired();

            builder.Property(x => x.PersonaId).IsRequired();
             
            builder.Property(x => x.Fecha)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.EstadoInscripcion).IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
