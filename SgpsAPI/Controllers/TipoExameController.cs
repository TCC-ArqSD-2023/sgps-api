using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("tipoExame")]
    public class TipoExameController : ControladorCrudBase<TipoExame, TipoExame>
    {
        public TipoExameController(ILogger<TipoExameController> logger, IServicoCrudBase<TipoExame> servico, IMapper mapper) : base(logger, servico, mapper)
        {
        }
    }
}
