namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AcreditacionMetaData : IEntityTypeConfiguration<Acreditacion>
    {
        public void Configure(EntityTypeBuilder<Acreditacion> builder)
        {
            builder.Property(x => x.Fecha)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.ProgramacionId).IsRequired();

            builder.Property(x => x.PersonaId).IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
