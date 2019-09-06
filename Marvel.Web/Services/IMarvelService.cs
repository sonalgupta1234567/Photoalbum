using Marvel.Web.Models;

namespace Marvel.Web.Services
{
    public interface IMarvelService
    {
        MarvelViewModel GetComics(string characterName);
    }
}