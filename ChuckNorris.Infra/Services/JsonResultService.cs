using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.Infra.Adapters;
using ChuckNorris.Infra.Adapters.Contracts;
using ChuckNorris.Infra.Contracts;
using ChuckNorris.Infra.Models;
using Newtonsoft.Json;

namespace ChuckNorris.Infra
{
    public class JsonResultService
        : IJsonResultService
    {
        private IClientAdapter _client;
        private IResponseMessageAdapter _response;

        public JsonResultService(IClientAdapter client, IResponseMessageAdapter response)
        {
            _client = client;
            _response = response;

        }

        public async Task<IResponseMessageAdapter> GetResponse(string query)
        {
            var httpResponse = await _client.GetAsync(query);
            _response.HttpResponseMessage = httpResponse;
            return _response;
        }

        public async Task<string> ResponseToString(IResponseMessageAdapter response)
        {
            return await response.ReadAsStringAsync();
        }


        public JsonResult JsonToObject(string jsonString)
        {
            return JsonConvert.DeserializeObject<JsonResult>(jsonString);
        }
    }
}