using Comunidad.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comunidad.Dominio.MetaData
{
    public class UsuarioMetaData : IEntityTypeConfiguration<Dominio.Entidades.Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
             
            //builder.HasData(Seed());

            
            
        }


        //public List<Usuario> Seed()
        //{
        //    var listaU = new List<Usuario>
        //    {
        //        new Usuario{Id = 1, EstaBorrado = false, Nombre = "Admin", Password = "Admin"}
        //    };

        //    return listaU;
        //}
    }
}
