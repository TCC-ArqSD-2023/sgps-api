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
    public class ExameServico : ServicoCrudBase<Exame>, IExameServico
    {
        public ExameServico(ILogger<ExameServico> logger, IRepositorioCrudBase<Exame> repositorio, IMapper mapper) : base(logger, repositorio, mapper)
        {
        }

        public Result AgendarExame(long exameId, long associadoId)
        {
            // TODO: validar associadoId

            var resultadoExame = ObterPorId(exameId);

            if (resultadoExame.IsFailed || resultadoExame.Value == null)
                return Result.Fail(resultadoExame.Errors);

            var exame = resultadoExame.Value;

            if (exame.Situacao != SituacaoAtendimentoEnum.Aberto)
                return Result.Fail("Este exame não está em aberto para ser agendado.");

            exame.PacienteId = associadoId;
            exame.Situacao = SituacaoAtendimentoEnum.AguardandoAutorizacao;

            return Atualizar(exameId, exame);
        }

        public Result AutorizarExame(long exameId)
        {
            // valida se está agendado
            var resultadoExame = ObterPorId(exameId);

            if (resultadoExame.IsFailed || resultadoExame.Value == null)
                return Result.Fail(resultadoExame.Errors);

            var exame = resultadoExame.Value;

            if (exame.Situacao != SituacaoAtendimentoEnum.AguardandoAutorizacao || 
                exame.PacienteId == null)
                return Result.Fail("Não é possível autorizar este exame pois ainda não foi agendado para um paciente.");

            exame.Situacao = SituacaoAtendimentoEnum.Agendado;

            return Atualizar(exameId, exame);
        }
    }
}
