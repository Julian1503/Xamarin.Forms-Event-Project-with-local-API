using System.Security.Cryptography.X509Certificates;

namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UbicacionMetaData : IEntityTypeConfiguration<Ubicacion>
    {
        public void Configure(EntityTypeBuilder<Ubicacion> builder)
        {
            builder.Property(x => x.Ciudad)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.CodigoPostal)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(x => x.Direccion)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.PaisId)
                .IsRequired(false);

            builder.Property(x => x.Provincia)
                .HasMaxLength(250)
                .IsRequired(false);
        }
    }
}
