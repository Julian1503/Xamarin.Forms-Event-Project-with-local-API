using Comunidad.Dominio.Repositorio;
using Comunidad.Interfaces.Usuario.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comunidad.Interfaces.Usuario
{
    public interface IUsuarioRepositorio 
    {
        Task Crear(UsuarioDto dto);

        Task<bool> VerificarSiExiste(string usuario);

        Task<bool> Login(string nombreUsuario, string contraseña);

        Task<IEnumerable<UsuarioDto>> GetByUsuario(string nombreUsuario);

    }
}
