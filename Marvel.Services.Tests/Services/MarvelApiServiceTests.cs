using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marvel.Services;
using Rhino.Mocks;
using RestSharp;
using Marvel.Services.Models;
using System.Collections.Generic;

namespace MarvelApiClientTests
{
    [TestClass]
    public class MarvelApiServiceTests
    {
        private IRestClient _restClient;
        private IRestRequestService _restRequest;
        private IMarvelApiService _apiService;
        private readonly string _privateKey = "privatekey";
        private readonly string _publicKey = "publickey";
        private readonly string _baseUrl = "baseUrl";
        private readonly string _characterResourceUrl = "characters";

        [TestInitialize]
        public void TestInit()
        {          
            _restClient  = MockRepository.GenerateMock<IRestClient>();
            _restRequest = MockRepository.GenerateMock<IRestRequestService>();
            _apiService  = new MarvelApiService(_publicKey,_privateKey, _baseUrl,_restClient, _restRequest);
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterByNameIsCalled_ThenCreateRequestIsCalled_WithCorrectParameters()
        {
            //act
            string name = "hulk";
            string requestUrl = string.Format("{0}?name={1}", _characterResourceUrl, name);
            var result = _apiService.GetCharacterByName(name);

            //assert
            _restRequest.AssertWasCalled(x => x.CreateRequest(requestUrl, Method.GET,_privateKey, _publicKey));
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterByNameIsCalled_ThenRestClientExecuteIsCalled_WithRestRequest()
        {
            //arrange
            var name = "Hulk";
            string requestUrl = string.Format("{0}?name={1}", _characterResourceUrl, name);
            var request = GetRestRequest(requestUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(Arg<string>.Is.Anything, Arg<Method>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything)).
                Return(request);

            //act
            var result = _apiService.GetCharacterByName(name);

            //assert
            _restClient.AssertWasCalled(c => c.Execute<CharacterResult>(request));
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterByNameIsCalled_ReturnsCharacterResult()
        {
            //arrange
            var name = "Hulk";
            string requestUrl = string.Format("{0}?name={1}", _characterResourceUrl, name);
            var request = GetRestRequest(requestUrl, Method.GET);
            var response = GetCharacterResponse();
            _restRequest.Stub(x => x.CreateRequest(Arg<string>.Is.Anything, Arg<Method>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything)).
                Return(request);

            _restClient.Stub(x => x.Execute<CharacterResult>(request)).Return(response);

            //act
            var result = _apiService.GetCharacterByName(name);

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CharacterResult));
            CollectionAssert.AreEqual(response.Data.Data.Results, result.Data.Results);
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterComicsIsCalled_ThenCreateRequestIsCalled_WithCorrectParameters()
        {
            //arrange
            int characterId = 1;
            string requestUrl = string.Format("{0}/{1}/comics", _characterResourceUrl, characterId);
           
            //act
            var result = _apiService.GetCharacterComics(characterId);

            //assert
            _restRequest.AssertWasCalled(x => x.CreateRequest(requestUrl, Method.GET, _privateKey, _publicKey));
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterComicsIsCalled_ThenRestClientExecuteIsCalled_WithRestRequest()
        {
            //arrange
            var request = GetRestRequest(_characterResourceUrl + "/comics",Method.GET);          
            _restRequest.Stub(x => x.CreateRequest(Arg<string>.Is.Anything, Arg<Method>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything)).
                Return(request);

            //act
            var result = _apiService.GetCharacterComics(1);

            //assert
            _restClient.AssertWasCalled(c => c.Execute<ComicResult>(request));
        }

        [TestMethod]
        public void GivenMarvelApiService_WhenGetCharacterComicsIsCalled_ReturnsCharacterComics()
        {
            //arrange
            var request = GetRestRequest(_characterResourceUrl + "/comics", Method.GET);
            var response = GetComicResponse();
            _restRequest.Stub(x => x.CreateRequest(Arg<string>.Is.Anything, Arg<Method>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything)).
                Return(request);
            _restClient.Stub(x => x.Execute<ComicResult>(request)).Return(response);

            //act
            var result = _apiService.GetCharacterComics(1);

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ComicResult));
            CollectionAssert.AreEqual(response.Data.Data.Results, result.Data.Results);
        }

     
        private RestResponse<CharacterResult> GetCharacterResponse()
        {
            var characters = GetCharacters();
            return new RestResponse<CharacterResult>()
            {
                Data = new CharacterResult()
                {
                    Data = new DataContainer<Character>()
                    {
                        Results = characters
                    }
                }
            };

        }

        private RestResponse<ComicResult> GetComicResponse()
        {
            return new RestResponse<ComicResult>()
            {
                Data = new ComicResult()
                {
                    Data = new DataContainer<Comic>()
                    {
                        Results = GetComics()
                    }
                }
            };
        }

        private RestRequest GetRestRequest(string resourceUrl, Method method)
        {
            return new RestRequest()
            {
                Resource = resourceUrl,
                Method = method
            };
        }

        private List<Character> GetCharacters()
        {
            return new List<Character>()
            {
                new Character()
                {
                    Id = 1,
                    Name = "Thor"
                },
                new  Character()
                {
                    Id = 5,
                    Name = "Hulk"
                }
            };
        }

        private List<Comic> GetComics()
        {
            return new List<Comic>()
            {
                new Comic()
                {
                    DigitalId = 1,
                    Title = "IronMan"
                },
                new Comic()
                {
                    DigitalId = 4,
                    Title = "SpiderMan"
                }
            };
        }
    }
}
