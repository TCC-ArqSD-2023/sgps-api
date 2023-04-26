using AutoMapper;
using FluentResults;
using GisaApiArq.Infra;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using GisaDominio.Enum;
using GisaDominio.Interfaces.Servicos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class ConsultaServico : ServicoCrudBase<Consulta>, IConsultaServico
    {
        public ConsultaServico(ILogger<ConsultaServico> logger, IRepositorioCrudBase<Consulta> repositorio, IMapper mapper) : base(logger, repositorio, mapper)
        {
        }

        public Result AgendarConsulta(long consultaId, long associadoId)
        {
            // TODO: validar associadoId

            var resultadoConsulta = ObterPorId(consultaId);

            if (resultadoConsulta.IsFailed || resultadoConsulta.Value == null)
                return Result.Fail(resultadoConsulta.Errors);

            var consulta = resultadoConsulta.Value;

            if (consulta.Situacao != SituacaoAtendimentoEnum.Aberto)
                return Result.Fail("Esta consulta não está em aberto para ser agendado.");

            consulta.PacienteId = associadoId;
            consulta.Situacao = SituacaoAtendimentoEnum.AguardandoAutorizacao;

            return Atualizar(consultaId, consulta);
        }
    }
}
