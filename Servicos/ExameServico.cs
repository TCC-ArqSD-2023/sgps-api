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
        private readonly IServicoCrudBase<Associado> _associadoServico;

        public ExameServico(
            ILogger<ExameServico> logger, 
            IRepositorioCrudBase<Exame> repositorio, 
            IMapper mapper,
            IServicoCrudBase<Associado> associadoServico) : base(logger, repositorio, mapper)
        {
            this._associadoServico = associadoServico;
        }

        public Result AgendarExame(long exameId, long associadoId)
        {
            var resultadoAssociado = _associadoServico.ObterPorId(associadoId);
            if (resultadoAssociado.IsFailed || resultadoAssociado.Value == null)
                return Result.Fail(resultadoAssociado.Errors);
            if (resultadoAssociado.Value.Situacao != SituacaoAssociadoEnum.Ativo)
                return Result.Fail("O associado não pode agendar exames pois está "+ Enum.GetName(resultadoAssociado.Value.Situacao) + ".");


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
            var resultadoExame = ObterPorId(exameId);

            if (resultadoExame.IsFailed || resultadoExame.Value == null)
                return Result.Fail(resultadoExame.Errors);

            var exame = resultadoExame.Value;

            if (exame.Situacao != SituacaoAtendimentoEnum.AguardandoAutorizacao || 
                exame.PacienteId == null)
                return Result.Fail("Não é possível autorizar este exame pois não foi agendado para um paciente.");

            exame.Situacao = SituacaoAtendimentoEnum.Agendado;

            return Atualizar(exameId, exame);
        }
    }
}
