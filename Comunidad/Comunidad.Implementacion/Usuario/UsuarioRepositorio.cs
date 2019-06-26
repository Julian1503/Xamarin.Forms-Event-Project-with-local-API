using AutoMapper;
using Comunidad.Dominio.Extension;
using Comunidad.Dominio.Repositorio;
using Comunidad.Infraestructura;
using Comunidad.Interfaces.Persona.DTOs;
using Comunidad.Interfaces.Ubicacion.DTOs;
using Comunidad.Interfaces.Usuario;
using Comunidad.Interfaces.Usuario.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Implementacion.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Usuario> _usuarioRepos;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepositorio(IRepositorio<Dominio.Entidades.Usuario> usuarioRepos, DataContext context)
        {
            _usuarioRepos = usuarioRepos;

            _context = context;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiles.MapperProfiles>());

            _mapper = config.CreateMapper();


        }


        public async Task Crear(UsuarioDto dto)
        {
            var nuevoUsuario = _mapper.Map<Dominio.Entidades.Usuario>(dto);

            await _usuarioRepos.Create(nuevoUsuario);
        }

        public async Task<IEnumerable<UsuarioDto>> GetByUsuario(string nombreUsuario)
        {
             Expression<Func<Dominio.Entidades.Usuario, bool>> pred = x => true;

                pred = pred.And(x => x.Nombre == nombreUsuario || x.Persona.Dni == nombreUsuario);

                var persona = await _usuarioRepos.GetByFilter(pred,
                    null, include: x => x.Include(navigationPropertyPath: per => per.Persona)
                    .Include(ub => ub.Persona.Ubicacion), true);


              var usuario = _mapper.Map<IEnumerable<Dominio.Entidades.Usuario>,IEnumerable<UsuarioDto>> (persona);
                return usuario;
                    //.Select(x => new UsuarioDto
                    //{
                    //    Id = x.Id,
                    //    Usuario = x.Nombre,
                    //    Persona = new PersonaDto
                    //    {
                    //        Id = x.PersonaId,
                    //        ApellidoCasada = x.Persona.ApellidoCasada,
                    //        Celular = x.Persona.Celular,
                    //        Apellido = x.Persona.Apellido,
                    //        Dni = x.Persona.Dni,
                    //        AltaPorMostrador = x.Persona.AltaPorMostrador,
                    //        Email = x.Persona.Email,
                    //        Nombre = x.Nombre,
                    //        Telefono = x.Persona.Telefono,
                    //        Ubicacion = new UbicacionDto
                    //        {
                    //            Ciudad = x.Persona.Ubicacion.Ciudad,
                    //            CodigoPostal = x.Persona.Ubicacion.CodigoPostal,
                    //            Direccion = x.Persona.Ubicacion.Direccion,
                    //            PaisId = x.Persona.Ubicacion.PaisId,
                    //            Provincia = x.Persona.Ubicacion.Provincia
                    //        },
                    //    },


            //}).ToList();

        }

        public async Task<bool> Login(string nombreUsuario, string contraseña)
        {
            var usuario =  _context.Usuarios.FirstOrDefault(x => x.Nombre == nombreUsuario && x.Password == contraseña);

            bool resultado = await Task.Run(() =>
            {
                if (usuario == null)
                {
                    return false;
                }

                return true;
            });

            return resultado;
        
    }

        public async Task<bool> VerificarSiExiste(string usuario)
        {
            var nombreUsuario =  _context.Usuarios.FirstOrDefault(x => x.Nombre == usuario);

            bool resultado = await Task.Run(() =>
            {
                if (nombreUsuario == null)
                {
                     return false;
                }

                    return true;
            });

            return resultado;
        }
    }
}
