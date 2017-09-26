using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.Infra.Adapters.Contracts;
using ChuckNorris.Infra.Models;

namespace ChuckNorris.Infra.Contracts
{
    public interface IJsonResultService
    {


        Task<IResponseMessageAdapter> GetResponse(string query);
        Task<string> ResponseToString(IResponseMessageAdapter response);

        JsonResult JsonToObject(string jsonString);
    }
}