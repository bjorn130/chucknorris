using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.Infra.Adapters;
using ChuckNorris.Infra.Adapters.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace ChuckNorris.Infra.Test.Services.JsonResultServiceTest
{

    public class Base_Test_JsonResult
    {
        protected JsonResultService _sut;
        protected IClientAdapter _client;
        protected Mock<IClientAdapter> _clientMock;
        protected Mock<IResponseMessageAdapter> _ResponseMock;

        public virtual void Initialize()
        {
            _client = new HttpClientAdapter("http://www.test.be");
            _clientMock = new Mock<IClientAdapter>();
            _ResponseMock = new Mock<IResponseMessageAdapter>();
            _sut = new JsonResultService(_client, _ResponseMock.Object);
        }
    }
    public class Given_Valid_Dependencies_When_Constructing_Instance
        : Base_Test_JsonResult
    {
        [Fact]
        public void Then_It_Should_Create_Valid_Instance()
        {
            Initialize();
            Assert.NotNull(_sut);
        }

    }
    public class Given_Valid_Client_And_Query
        : Base_Test_JsonResult
    {

        public override void Initialize()
        {
            base.Initialize();
            _clientMock
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            _ResponseMock
                .Setup(x => x.ReadAsStringAsync())
                .Returns(Task.FromResult("hallo"));

        }
        [Fact]
        public void Then_It_Should_Have_Valid_Response()
        {
            Initialize();
            IResponseMessageAdapter result = _sut.GetResponse("test").Result;

            Assert.Equal(new HttpResponseMessage(HttpStatusCode.OK).StatusCode, result.StatusCode);
            //Assert.Equal(new HttpResponseMessage(HttpStatusCode.OK).StatusCode, result.StatusCode);
        }

        [Fact]
        public void Then_It_Should_Return_A_Valid_String()
        {
            Initialize();
            IResponseMessageAdapter result = _sut.GetResponse(It.IsAny<string>()).Result;
            var stringResult = _sut.ResponseToString(result).Result;
            Assert.Equal("hallo", stringResult);

        }

        [Fact]
        public void Then_It_Should_Fill_In_JsonObject()
        {
            Initialize();
            var result = _sut.JsonToObject("{ \"type\": \"success\", \"value\": [ { \"id\": 310, \"joke\": \"182,000 Americans die from Chuck Norris-related accidents every year.\", \"categories\": [] }, { \"id\": 120, \"joke\": \"Chuck Norris played Russian Roulette with a fully loaded gun and won.\", \"categories\": [] }, { \"id\": 28, \"joke\": \"Chuck Norris is not hung like a horse. Horses are hung like Chuck Norris.\", \"categories\": [] } ]  }");
            Assert.NotNull(result.value[0]);
            Assert.Equal("182,000 Americans die from Chuck Norris-related accidents every year.", result.value[0].joke);
        }

    }
}
