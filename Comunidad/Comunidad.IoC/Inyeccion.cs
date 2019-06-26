using AutoMapper;
using Comunidad.Dominio.Repositorio;
using Comunidad.Implementacion.Acreditacion;
using Comunidad.Implementacion.Entrada;
using Comunidad.Implementacion.Evento;
using Comunidad.Implementacion.Inscripcion;
using Comunidad.Implementacion.Pais;
using Comunidad.Implementacion.Persona;
using Comunidad.Implementacion.Programacion;
using Comunidad.Implementacion.TemaEvento;
using Comunidad.Implementacion.TipoEvento;
using Comunidad.Implementacion.Usuario;
using Comunidad.Infraestructura;
using Comunidad.Infraestructura.Repositorio;
using Comunidad.Interfaces.Acreditacion.DTOs;
using Comunidad.Interfaces.Entrada;
using Comunidad.Interfaces.Evento;
using Comunidad.Interfaces.Inscripcion;
using Comunidad.Interfaces.Pais;
using Comunidad.Interfaces.Pais.DTOs;
using Comunidad.Interfaces.Persona;
using Comunidad.Interfaces.Programacion;
using Comunidad.Interfaces.TemaEvento;
using Comunidad.Interfaces.TipoEvento;
using Comunidad.Interfaces.Usuario;
using Comunidad.Interfaces.Usuario.DTOs;
using Microsoft.Extensions.DependencyInjection;
 
namespace Comunidad.IoC
{
    public class Inyeccion
    { 
        public static void ConfigurationServices (IServiceCollection servicios)
        {

            servicios.AddDbContext<DataContext>();
 

            servicios.AddTransient<IEventoRepositorio,EventoRepositorio>();
            servicios.AddTransient<IEventoRepositorio, EventoRepositorio>();
            servicios.AddTransient<ITemaEventoServicio, TemaEventoServicio>();
            servicios.AddTransient<ITipoEventoServicio, TipoEventoServicio>();
            servicios.AddTransient<IPaisRepositorio, PaisServicio>();
            servicios.AddTransient<IInscripcionRepositorio, InscripcionRepositorio>();
            servicios.AddTransient<IEntradaRepositorio, EntradaRepositorio>();
            servicios.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            servicios.AddTransient<IAcreditacionRepositorio, AcreditacionServicio>();
            servicios.AddTransient<IProgramacionRepositorio, ProgramacionRepositorio>();
            servicios.AddTransient<IPersonaRepositorio, PersonaRepositorio>();

            servicios.AddTransient<IRepositorio<Dominio.Entidades.Persona>, Repositorio<Dominio.Entidades.Persona>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Evento>, Repositorio<Dominio.Entidades.Evento>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.TemaEvento>, Repositorio<Dominio.Entidades.TemaEvento>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.TipoEvento>, Repositorio<Dominio.Entidades.TipoEvento>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Pais>, Repositorio<Dominio.Entidades.Pais>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Inscripcion>, Repositorio<Dominio.Entidades.Inscripcion>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Entrada>, Repositorio<Dominio.Entidades.Entrada>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Usuario>, Repositorio<Dominio.Entidades.Usuario>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Acreditacion>, Repositorio<Dominio.Entidades.Acreditacion>>();
            servicios.AddTransient<IRepositorio<Dominio.Entidades.Programacion>, Repositorio<Dominio.Entidades.Programacion>>();
        }

       


    }
}
