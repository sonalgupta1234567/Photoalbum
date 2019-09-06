using Marvel.Services;
using Marvel.Web.Settings;
using System.Linq;

namespace Marvel.Web.Services
{
    public class CharacterService : ICharacterService
    {
        private IMarvelApiService _marvelApiService;
        private IMarvelConfigurationManager _marvelConfigurationManager;

        public CharacterService()
        {
            _marvelConfigurationManager = new MarvelConfigurationManager();
            _marvelApiService = new MarvelApiService(
                _marvelConfigurationManager.MarvelPublicKey, 
                _marvelConfigurationManager.MarvelPrivateKey,
                _marvelConfigurationManager.MarvelBaseUrl);
        }

        internal CharacterService(IMarvelApiService marvelApiService)
        {
            _marvelApiService = marvelApiService;
        }

        public int? GetCharacterId(string name)
        {
            var response = _marvelApiService.GetCharacterByName(name);
            var results = response?.Data?.Results;
            if(results != null && results.Any())
            {
                return results.First().Id;
            }
            return null;
        }
    }
}