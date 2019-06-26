namespace Comunidad.Dominio.MetaData
{
    using Comunidad.Constantes;
    using Comunidad.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class EntradaMetaData : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.Property(x => x.EventoId).IsRequired();

            builder.Property(x => x.Nombre)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.CantidadDisponible)
                .IsRequired();

            builder.Property(x => x.Precio)
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(x => x.TipoEntrada).IsRequired();

            //builder.Property(x => x.TipoEntrada)
            //    .HasConversion(x => x.ToString(),
            //           e => (TipoEntrada)Enum.Parse(typeof(TipoEntrada), e))
            //    .IsRequired();

            builder.Property(x => x.TipoEntrada).IsRequired();

            builder.HasQueryFilter(x => x.EstaBorrado == false);
        }
    }
}
