using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.Infra.Adapters.Contracts;

namespace ChuckNorris.Infra.Adapters
{
    public class HttpResponseMessageAdapter
        : IResponseMessageAdapter
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpResponseMessageAdapter(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
            StatusCode = httpResponseMessage.StatusCode;
        }
        public async Task<string> ReadAsStringAsync()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}