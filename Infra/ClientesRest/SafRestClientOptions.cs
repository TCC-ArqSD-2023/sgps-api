using GisaDominio.Entidades;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ClientesRest
{
    public class SafRestClientOptions : RestClientOptions
    {
        public SafRestClientOptions(IConfiguration configuration) 
            : base(configuration["SafEndpoint"] ?? "")
        {
        }
    }
}
