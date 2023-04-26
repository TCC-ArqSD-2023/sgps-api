using AutoMapper;
using GisaApiArq.API;
using GisaDominio.Entidades;
using GisaDominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using SgpsAPI.DTO;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController : ControladorCrudBase<Consulta, ConsultaDTO>
    {
        protected new readonly IConsultaServico _servico;

        public ConsultaController(ILogger<ConsultaController> logger, IConsultaServico servico, IMapper mapper) : base(logger, servico, mapper)
        {
            _servico = servico;
        }

        
    }
}
