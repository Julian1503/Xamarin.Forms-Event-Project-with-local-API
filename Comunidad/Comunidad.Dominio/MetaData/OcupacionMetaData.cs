namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OcupacionMetaData : IEntityTypeConfiguration<Ocupacion>
    {
        public void Configure(EntityTypeBuilder<Ocupacion> builder)
        {
            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .HasField("_descripcion")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
