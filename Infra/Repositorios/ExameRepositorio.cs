using AutoMapper;
using GisaApiArq.Infra;
using GisaDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class ExameRepositorio : RepositorioCrudBase<Exame>
    {
        public ExameRepositorio(DbContext contexto, ILogger<ExameRepositorio> logger, IMapper mapper) : base(contexto, logger, mapper)
        {
        }

        public override IEnumerable<Exame> ObterTodos()
        {
            return _colecao
                .Include(p => p.TipoExame)
                .AsEnumerable();
        }

        public override Exame? ObterPorId(long id)
        {
            return _colecao
                .Include(p => p.TipoExame)
                .SingleOrDefault(e => e.Id == id);
        }
    }
}
