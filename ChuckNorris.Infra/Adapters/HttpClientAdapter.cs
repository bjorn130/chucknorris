using System;
using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.Infra.Adapters.Contracts;

namespace ChuckNorris.Infra.Adapters
{
    public class HttpClientAdapter
        :IClientAdapter
    {
        
        private HttpClient _httpClient;

        public HttpClientAdapter(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<HttpResponseMessage> GetAsync(string query)
        {
            return await _httpClient.GetAsync(query);
        }
    }
}