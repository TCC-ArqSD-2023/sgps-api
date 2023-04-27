using AutoMapper;
using GisaApiArq.API;
using GisaApiArq.Dominio.Erros;
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

        [HttpPost("agendar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<FluentResults.Error>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<FluentResults.Error>), StatusCodes.Status500InternalServerError)]
        public IActionResult AgendarExame([FromBody] AgendarExameDTO dto)
        {
            _logger.LogInformation($"Acionado recurso {nameof(AgendarExame)}.");
            var resultado = _servico.AgendarConsulta(dto.ExameId, dto.PacienteId);

            if (resultado.IsFailed)
            {
                if (resultado.HasError<NaoEncontradoError>())
                    return NotFound(resultado.Errors.Select(e => e.Message));
                return retornarErroGenerico(resultado.Errors.Select(e => e.Message));
            }

            return NoContent();
        }


    }
}
