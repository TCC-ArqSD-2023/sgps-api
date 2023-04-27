using AutoMapper;
using GisaApiArq.Infra;
using GisaDominio.Entidades;
using Infra.ClientesRest;
using Infra.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class AssociadoRepositorio : IRepositorioCrudBase<Associado>
    {

        private readonly RestClient _restClient;
        private readonly IMapper _mapper;

        public AssociadoRepositorio(IMapper mapper, SafRestClientOptions restClientOptions)
        {
            _restClient = new RestClient(restClientOptions);
            this._mapper = mapper;
        }

        public void Atualizar(Associado entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Associado entidade)
        {
            throw new NotImplementedException();
        }

        public Associado? ObterPorId(long id)
        {
            var request = new RestRequest("associado/" + id);

            var response = _restClient.Get(request);
            if(response == null || response.StatusCode == HttpStatusCode.NotFound)
                return null;

            try
            {
                var associadoDTO = JsonSerializer.Deserialize<AssociadoDTO>(response.Content ?? "");
                var associado = _mapper.Map<Associado>(associadoDTO);

                return associado;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public IEnumerable<Associado> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(long id)
        {
            throw new NotImplementedException();
        }
    }
}
