using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("exame")]
    public class ExameController : ControladorCrudBase<Exame, Exame>
    {
        public ExameController(ILogger<ControladorCrudBase<Exame, Exame>> logger, IServicoCrudBase<Exame> servico, IMapper mapper) : base(logger, servico, mapper)
        {
        }
    }
}
