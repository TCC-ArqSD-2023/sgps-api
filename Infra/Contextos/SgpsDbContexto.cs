using GisaDominio.Entidades;
using Infra.Contextos.DbMap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contextos
{
    public class SgpsDbContexto : DbContext
    {
        public SgpsDbContexto(DbContextOptions<SgpsDbContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("sgps");

            new TipoExameDbMap(modelBuilder.Entity<TipoExame>());
            new ExameDbMap(modelBuilder.Entity<Exame>());
            new ConsultaDbMap(modelBuilder.Entity<Consulta>());
        }
    }
}
