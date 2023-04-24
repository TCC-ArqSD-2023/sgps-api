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
    public class SafRestClient : IDisposable
    {
        readonly RestClient _restClient;
        public SafRestClient(IConfiguration configuration)
        {
            var options = new RestClientOptions(configuration["SafEndpoint"] ?? "");

            _restClient = new RestClient(options)
            {
                // Authenticator = new TwitterAuthenticator("https://api.twitter.com", apiKey, apiKeySecret)
            };
        }

        public void Dispose()
        {
            _restClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
