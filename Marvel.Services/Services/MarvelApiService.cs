using Marvel.Services.Models;
using RestSharp;

namespace Marvel.Services
{
    public class MarvelApiService : IMarvelApiService
    {      
        private readonly IRestClient _restClient;
        private readonly IRestRequestService _restRequest;
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _baseUrl;
        private readonly string _characterResourceUrl = "characters";

        public MarvelApiService(string publicKey, string privateKey, string baseUrl)
        {           
            _restRequest = new RestRequestService();
            _restClient = new RestClient(baseUrl);
            _publicKey = publicKey;
            _privateKey = privateKey;
            _baseUrl = baseUrl;
        }

        internal MarvelApiService(string publicKey, string privateKey, string baseUrl,IRestClient restClient, IRestRequestService restRequest)
        {
            _restClient = restClient;
            _restRequest = restRequest;
            _privateKey = privateKey;
            _publicKey = publicKey;
            _baseUrl = baseUrl;
        }

        public CharacterResult GetCharacterByName(string name)
        {
            string requestUrl = string.Format("{0}?name={1}", _characterResourceUrl, name);
            var request = _restRequest.CreateRequest(requestUrl, Method.GET, _privateKey, _publicKey);
            var response = _restClient.Execute<CharacterResult>(request);
            return response?.Data;
        }

        public ComicResult GetCharacterComics(int characterId)
        {
            string requestUrl = string.Format("{0}/{1}/comics", _characterResourceUrl, characterId);
            var request = _restRequest.CreateRequest(requestUrl, Method.GET,_privateKey, _publicKey);
            var response = _restClient.Execute<ComicResult>(request);
            return response?.Data;
        }
    }
}