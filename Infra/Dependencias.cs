using GisaApiArq.Infra;
using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class Dependencias
    {
        public static void ConfigurarServices(IConfiguration configuration, IServiceCollection services)
        {
            var connString = configuration["ConnectionStrings:SafDbSqlServer"];
            connString += configuration["DbSenha"];
            services.AddDbContext<SgpsDbContexto>(options =>
                options
                .UseSqlServer(connString)
            );
            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped(typeof(IServicoCrudBase<>), typeof(ServicoCrudBase<>));
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IRepositorioCrudBase<>), typeof(RepositorioCrudBase<>));
            services.AddScoped<DbContext, SgpsDbContexto>();
        }
    }
}
