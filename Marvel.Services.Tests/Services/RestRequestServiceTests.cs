using Marvel.Services;
using Marvel.Services.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Rhino.Mocks;

namespace MarvelApiClientTests.Services
{
    [TestClass]
    public class RestRequestServiceTests
    {
        private ITimeStamp _timeStamp;
        private IHash _hash;
        private IRestRequestService _service;

        [TestInitialize]
        public void TestInit()
        {
            _timeStamp = MockRepository.GenerateMock<ITimeStamp>();
            _timeStamp.Stub(c => c.GetTimestamp()).Return("09/09/2018 00:00:00");
            _hash = MockRepository.GenerateMock<IHash>();
            _hash.Stub(x => x.GetHash(Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return("jhasgdj");
            _service = new RestRequestService(_timeStamp, _hash);
        }

        [TestMethod]
        public void GivenRestRequestService_WhenCreateRequestIsCalled_ReturnsRestRequest()
        {
            //act
            var result = _service.CreateRequest("resource", Method.GET, "PrivateKey", "publickey");
            var expectedList = result.Parameters;

            //assert
            Assert.AreEqual(result.Resource, "resource");
            Assert.AreEqual(result.Method, Method.GET);
            Assert.AreEqual(expectedList[0].Name, "Accept");
            Assert.AreEqual(expectedList[0].Value, "application/json");
            Assert.AreEqual(expectedList[1].Name, "ts");
            Assert.AreEqual(expectedList[1].Value, "09/09/2018 00:00:00");
            Assert.AreEqual(expectedList[2].Name, "apikey");
            Assert.AreEqual(expectedList[2].Value, "publickey");
            Assert.AreEqual(expectedList[3].Name, "hash");
            Assert.AreEqual(expectedList[3].Value, "jhasgdj");
        }
    }
}
