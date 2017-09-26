using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using ChuckNorris.Domain.Repositories;
using ChuckNorris.Domain.Test.Repositories;
using ChuckNorris.Infra;
using ChuckNorris.Infra.Adapters;
using ChuckNorris.Infra.Adapters.Contracts;
using ChuckNorris.Infra.Contracts;
using Moq;
using Xunit;

namespace ChuckNorris.Domain.Test.Repositories.JokeRepositoryTest
{

    public class Base_Test_JsonResultRepository
    {

        protected JokeRepository _sut;

        public virtual void Initialize()
        {
            _sut = new JokeRepository();

        }
    }

    public class Given_Valid_Dependencies_When_Constructing_Instance
        : Base_Test_JsonResultRepository
    {
        private Mock<IJsonResultService> _jsonResultServiceMock;

        public override void Initialize()
        {
            base.Initialize();
            _jsonResultServiceMock = new Mock<IJsonResultService>();

        }

        [Fact]
        public void Then_It_Should_Create_Valid_Instance()
        {

            Assert.NotNull(_sut);
        }

        //[Fact]
        //public void Then_It_Should_Create_A_Joke()
        //{
        //    IResponseMessageAdapter test;
        //    _jsonResultServiceMock
        //        .Setup(x => x.GetResponse(It.IsAny<string>()))
        //        .Returns(Task.FromResult(test = new HttpResponseMessageAdapter(new HttpResponseMessage(HttpStatusCode.OK))));

        //    _jsonResultServiceMock
        //        .Setup(x => x.ResponseToString(It.IsAny<IResponseMessageAdapter>()))
        //        .Returns(Task.FromResult("si fly"));



        //    _jsonResultServiceMock
        //        .Setup(x => x.JsonToObject("{ \"type\": \"success\", \"value\": [ { \"id\": 310, \"joke\": \"182,000 Americans die from Chuck Norris-related accidents every year.\", \"categories\": [] }, { \"id\": 120, \"joke\": \"Chuck Norris played Russian Roulette with a fully loaded gun and won.\", \"categories\": [] }, { \"id\": 28, \"joke\": \"Chuck Norris is not hung like a horse. Horses are hung like Chuck Norris.\", \"categories\": [] } ]  }"))
        //        .Returns(Task.FromResult(Jsonresult);

        //    //Initialize();
        //    //Assert.NotNull(_sut);
        //}
    }

}
