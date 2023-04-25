using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using SgpsAPI.DTO;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController : ControladorCrudBase<Consulta, ConsultaDTO>
    {
        public ConsultaController(ILogger<ConsultaController> logger, IServicoCrudBase<Consulta> servico, IMapper mapper) : base(logger, servico, mapper)
        {
        }
    }
}
