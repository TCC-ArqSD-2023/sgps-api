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
                .ReverseMap();
            CreateMap<ConsultaDTO, Consulta>()
                .ReverseMap();
        }
    }
}
