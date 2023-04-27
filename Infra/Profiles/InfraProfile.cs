using AutoMapper;
using GisaDominio.Entidades;
using Infra.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Profiles
{
    public class InfraProfile : Profile
    {
        public InfraProfile() 
        {
            CreateMap<AssociadoDTO, Associado>()
                .ReverseMap();
        }
    }
}
