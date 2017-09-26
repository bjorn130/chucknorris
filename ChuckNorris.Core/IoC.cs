using System.Reflection.Emit;
using Autofac;
using ChuckNorris.Infra;
using ChuckNorris.Infra.Adapters;
using ChuckNorris.Infra.Adapters.Contracts;
using ChuckNorris.Infra.Contracts;

namespace ChuckNorris.Core
{
    public class IoC
    {
        static void Build()
        {
            var container = new ContainerBuilder();
            container
                .RegisterType<JsonResultService>()
                .As<IJsonResultService>();
            container
                .RegisterType<HttpClientAdapter>()
                .As<IClientAdapter>();
            container
                .RegisterType<HttpResponseMessageAdapter>()
                .As<IResponseMessageAdapter>();


        }
    }
}