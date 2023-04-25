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



        //[HttpPost("{intervalo}/{quantidade}")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(List<FluentResults.Error>), StatusCodes.Status500InternalServerError)]
        //public IActionResult Inserir([FromBody] ExameDTO primeiro, [FromRoute] int intervalo = 30, [FromRoute] int quantidade = 1)
        //{
        //    _logger.LogInformation($"Acionado recurso {nameof(Inserir)}.");
        //    var resultado = _servico.Inserir(converterDTO(primeiro));

        //    if (resultado.IsFailed)
        //        return retornarErroGenerico(resultado.Errors);

        //    var entidade = resultado.Value;

        //    return CreatedAtAction(nameof(ObterPorId), new { id = entidade.Id }, entidade);
        //}
    }
}
