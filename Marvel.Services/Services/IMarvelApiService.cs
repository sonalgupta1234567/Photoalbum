using Marvel.Services.Models;

namespace Marvel.Services
{
    public interface IMarvelApiService
    {
        CharacterResult GetCharacterByName(string name);
        ComicResult GetCharacterComics(int characterId);
    }
}