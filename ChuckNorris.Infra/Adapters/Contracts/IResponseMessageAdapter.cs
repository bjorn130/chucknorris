using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChuckNorris.Infra.Adapters.Contracts
{
    public interface IResponseMessageAdapter
    {
        HttpStatusCode StatusCode { get; set; }
        HttpResponseMessage HttpResponseMessage { get; set; }

        Task<string> ReadAsStringAsync();
    }
}