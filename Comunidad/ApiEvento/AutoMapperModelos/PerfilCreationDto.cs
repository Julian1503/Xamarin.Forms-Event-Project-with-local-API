using ApiEvento.Models.AcreditacionModel;
using ApiEvento.Models.EventoModel;
using ApiEvento.Models.InscripcionModel;
using ApiEvento.Models.PersonaCreationDto;
using ApiEvento.Models.UsuarioModel;
using AutoMapper;
using Comunidad.Interfaces.Acreditacion.DTOs;
using Comunidad.Interfaces.Evento.DTOs;
using Comunidad.Interfaces.Inscripcion.DTOs;
using Comunidad.Interfaces.Persona.DTOs;
using Comunidad.Interfaces.Usuario.DTOs;


namespace ApiEvento.AutoMapperModelos
{
    public class PerfilCreationDto : Profile
    {
        public PerfilCreationDto()
        {
            CreateMap<UsuarioCreationDto, UsuarioDto>().ReverseMap();

            CreateMap<EventoCreationDto, EventoDto>().ReverseMap();

            CreateMap<InscripcionCreationDto, InscripcionDto>().ReverseMap();
             
            CreateMap<AcreditacionCreationDto, AcreditacionDto>().ReverseMap();

            CreateMap<PersonaCreationDto, PersonaDto>().ReverseMap();
            
        }


    }
}
