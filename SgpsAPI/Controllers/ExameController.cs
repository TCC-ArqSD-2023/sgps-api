using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using GisaDominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Servicos;
using SgpsAPI.DTO;

namespace SgpsAPI.Controllers
{
    [ApiController]
    [Route("exame")]
    public class ExameController : ControladorCrudBase<Exame, ExameDTO>
    {
        protected new readonly IExameServico _servico;

        public ExameController(ILogger<ExameController> logger, IExameServico servico, IMapper mapper) : base(logger, servico, mapper)
        {
            _servico = servico;
        }


        [HttpPost("agendarExame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<FluentResults.Error>), StatusCodes.Status500InternalServerError)]
        public IActionResult AgendarExame([FromBody] AgendarExameDTO dto)
        {
            _logger.LogInformation($"Acionado recurso {nameof(AgendarExame)}.");
            var resultado = _servico.AgendarExame(dto.ExameId, dto.PacienteId);

            if (resultado.IsFailed)
                return retornarErroGenerico(resultado.Errors.Select(e => e.Message));

            return NoContent();
        }


        [HttpPost("autorizarExame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<FluentResults.Error>), StatusCodes.Status500InternalServerError)]
        public IActionResult AutorizarExame([FromBody] long exameId)
        {
            _logger.LogInformation($"Acionado recurso {nameof(AutorizarExame)}.");
            var resultado = _servico.AutorizarExame(exameId);

            if (resultado.IsFailed)
                return retornarErroGenerico(resultado.Errors.Select(e => e.Message));

            return NoContent();
        }
    }
}
