 namespace MapperProfiles
{
    using AutoMapper;
    using Comunidad.Dominio.Entidades;
    using Comunidad.Interfaces.Acreditacion.DTOs;
    using Comunidad.Interfaces.Entrada.DTOs;
    using Comunidad.Interfaces.Evento.DTOs;
    using Comunidad.Interfaces.Inscripcion.DTOs;
    using Comunidad.Interfaces.Pais.DTOs;
    using Comunidad.Interfaces.Persona.DTOs;
    using Comunidad.Interfaces.Programacion.DTOs;
    using Comunidad.Interfaces.TemaEvento.DTOs;
    using Comunidad.Interfaces.TipoEvento.DTOs;
    using Comunidad.Interfaces.Ubicacion.DTOs;
    using Comunidad.Interfaces.Usuario.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {

            CreateMap<InscripcionDto, Inscripcion>().ReverseMap();

             
            CreateMap<EventoDto, Evento>().ReverseMap();

            CreateMap<ProgramacionDto, List<Programacion>>();

            CreateMap<EntradaDto, List<Entrada>>();

            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Usuario)).ReverseMap();
                
            CreateMap<TemaEventoDto, TemaEvento>().ReverseMap();

            CreateMap<PaisDto, Pais>().ReverseMap();

            CreateMap<TipoEventoDto, TipoEvento>().ReverseMap();

            CreateMap<EntradaDto, Entrada>().ReverseMap();

            CreateMap<UbicacionDto, Ubicacion>().ReverseMap();

            CreateMap<AcreditacionDto, Acreditacion>().ReverseMap();

            CreateMap<ProgramacionDto, Programacion>().ReverseMap();

            CreateMap<PersonaDto, Persona>().ReverseMap();

        }

        

    }
}
