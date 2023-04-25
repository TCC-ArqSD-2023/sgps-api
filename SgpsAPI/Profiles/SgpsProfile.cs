using AutoMapper;
using GisaDominio.Entidades;
using SgpsAPI.DTO;

namespace SgpsAPI.Profiles
{
    public class SgpsProfile : Profile
    {
        public SgpsProfile()
        {
            CreateMap<Exame, Exame>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<Consulta, Consulta>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<TipoExame, TipoExame>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            CreateMap<ExameDTO, Exame>()
                .ReverseMap()
                .ForMember(e => e.TipoExameNome, opt => opt.MapFrom(e => e.TipoExame.Nome))
                .ForMember(e => e.ConveniadoNome, opt => opt.MapFrom(e => e.Conveniado.Nome))
                .ForMember(e => e.PacienteNome, opt => opt.MapFrom(e => e.Paciente == null ? null : e.Paciente.Nome + " " + e.Paciente.Sobrenome));
            CreateMap<ConsultaDTO, Consulta>()
                .ReverseMap()
                .ForMember(c => c.PrestadorNome, opt => opt.MapFrom(e => e.Prestador.Nome))
                .ForMember(c => c.PacienteNome, opt => opt.MapFrom(e => e.Paciente.Nome));
        }
    }
}
