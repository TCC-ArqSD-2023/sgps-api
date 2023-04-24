using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using SgpsAPI.DTO;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("exame")]
    public class ExameController : ControladorCrudBase<Exame, ExameDTO>
    {
        public ExameController(ILogger<ExameController> logger, IServicoCrudBase<Exame> servico, IMapper mapper) : base(logger, servico, mapper)
        {
        }
    }
}
