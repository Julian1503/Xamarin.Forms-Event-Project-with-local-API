namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProgramacionMetaData : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            builder.Property(x => x.FechaDesde)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.FechaHasta)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.HoraEntrada)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.HoraSalida)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
