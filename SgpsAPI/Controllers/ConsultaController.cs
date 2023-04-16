using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("consulta")]
    public class ConsultaController : ControladorCrudBase<Consulta, Consulta>
    {
        public ConsultaController(ILogger<ControladorCrudBase<Consulta, Consulta>> logger, IServicoCrudBase<Consulta> servico, IMapper mapper) : base(logger, servico, mapper)
        {
        }
    }
}
