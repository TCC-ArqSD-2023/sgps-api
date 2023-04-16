using GisaDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contextos.DbMap
{
    public class ExameDbMap
    {
        public ExameDbMap(EntityTypeBuilder<Exame> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TipoExame)
                .WithMany()
                .HasForeignKey(x => x.TipoExameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Ignore(x => x.Paciente);
            builder.Ignore(x => x.Conveniado);
        }
    }
}
