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
        private readonly IServicoCrudBase<Associado> _associadoServico;

        public ConsultaServico(
            ILogger<ConsultaServico> logger, 
            IRepositorioCrudBase<Consulta> repositorio, 
            IMapper mapper,
            IServicoCrudBase<Associado> associadoServico) : base(logger, repositorio, mapper)
        {
            this._associadoServico = associadoServico;
        }

        public Result AgendarConsulta(long consultaId, long associadoId)
        {
            var resultadoAssociado = _associadoServico.ObterPorId(associadoId);
            if (resultadoAssociado.IsFailed || resultadoAssociado.Value == null)
                return Result.Fail(resultadoAssociado.Errors);
            if (resultadoAssociado.Value.Situacao != SituacaoAssociadoEnum.Ativo)
                return Result.Fail("O associado não pode agendar consultas pois está " + Enum.GetName(resultadoAssociado.Value.Situacao) + ".");

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
