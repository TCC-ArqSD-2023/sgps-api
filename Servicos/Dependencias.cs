using GisaApiArq.Servicos;
using GisaDominio.Entidades;
using GisaDominio.Interfaces.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public static class Dependencias
    {
        public static void ConfigurarServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped(typeof(IExameServico), typeof(ExameServico));
            services.AddScoped(typeof(IConsultaServico), typeof(ConsultaServico));
            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped(typeof(IServicoCrudBase<>), typeof(ServicoCrudBase<>));

            Infra.Dependencias.ConfigurarServices(configuration, services);
        }
    }
}
