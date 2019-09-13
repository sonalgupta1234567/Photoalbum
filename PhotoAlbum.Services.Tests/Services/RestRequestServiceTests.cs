using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Services;
using RestSharp;

namespace MarvelApiClientTests.Services
{
    [TestClass]
    public class RestRequestServiceTests
    {      
        private IRestRequestService _service;

        [TestInitialize]
        public void TestInit()
        {
             _service = new RestRequestService();
        }

        [TestMethod]
        public void GivenRestRequestService_WhenCreateRequestIsCalled_ReturnsRestRequest()
        {
            //act
            var result = _service.CreateRequest("resource", Method.GET);

            //assert
            Assert.AreEqual(result.Resource, "resource");
            Assert.AreEqual(result.Method, Method.GET);
            Assert.AreEqual(result.Parameters[0].Name, "Accept");
            Assert.AreEqual(result.Parameters[0].Value, "application/json");
        }
    }
}
