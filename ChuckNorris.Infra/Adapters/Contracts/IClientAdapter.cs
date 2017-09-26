using System.Net.Http;
using System.Threading.Tasks;

namespace ChuckNorris.Infra.Adapters.Contracts
{
    public interface IClientAdapter
    {
        Task<HttpResponseMessage> GetAsync(string query);
    }
}