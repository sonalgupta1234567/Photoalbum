using Marvel.Web.Models;

namespace Marvel.Web.Services
{
    public class MarvelService : IMarvelService
    {
        private ICharacterService _characterService;
        private IComicService _comicService;
        public MarvelService()
        {
            _characterService = new CharacterService();
            _comicService = new ComicService();
        }

        internal MarvelService(ICharacterService characterService, IComicService comicService)
        {
            _characterService = characterService;
            _comicService = comicService;
        }

        public MarvelViewModel GetComics(string characterName)
        {
            var result = new MarvelViewModel();
            var characterId = _characterService.GetCharacterId(characterName);
            if(characterId.HasValue)
            {
                result.Comics = _comicService.GetComics(characterId.Value);
            }
            result.CharacterName = characterName;
            return result;
        }
    }
}