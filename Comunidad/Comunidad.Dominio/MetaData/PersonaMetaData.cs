namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonaMetaData : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            
           builder.Property(x => x.Apellido)
                .HasField("_apellido")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ApellidoCasada)
                .HasField("_apellidoCasada")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasField("_nombre")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Dni)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Telefono)
                .HasMaxLength(25)
                .IsRequired(false);

            builder.Property(x => x.Celular)
                .HasMaxLength(25)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(250)                
                .IsRequired(false);

            builder.OwnsOne(x => x.Ubicacion, dir =>
            {
                dir.Property(x => x.Direccion).HasColumnName("Direccion");

                dir.Property(x => x.Ciudad).HasColumnName("Ciudad");

                dir.Property(x => x.Provincia).HasColumnName("Provincia");

                dir.Property(x => x.CodigoPostal).HasColumnName("CodigoPostal");

                dir.Property(x => x.PaisId).HasColumnName("PaisId");
            });

            //builder.OwnsOne(x => x.Usuario, usu =>
            //{
            //    usu.Property(x => x.Nombre).HasColumnName("Nombre");

            //    usu.Property(x => x.Password).HasColumnName("Password");

            //});
            


            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
