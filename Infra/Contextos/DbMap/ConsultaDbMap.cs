using GisaDominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contextos.DbMap
{
    public class ConsultaDbMap
    {
        public ConsultaDbMap(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Paciente);
            builder.Ignore(x => x.Prestador);
        }
    }
}
