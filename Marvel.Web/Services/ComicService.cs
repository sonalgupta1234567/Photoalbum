using System.Collections.Generic;
using System.Linq;
using Marvel.Services;
using Marvel.Web.Mappers;
using Marvel.Web.Models;
using Marvel.Web.Settings;

namespace Marvel.Web.Services
{
    public class ComicService :  IComicService
    {
        private IComicViewModelMapper _comicViewModelMapper;
        private IMarvelApiService _marvelApiService;
        private IMarvelConfigurationManager _marvelConfigurationManager;

        public ComicService()
        {
            _comicViewModelMapper = new ComicViewModelMapper();
            _marvelConfigurationManager = new MarvelConfigurationManager();
            _marvelApiService = new MarvelApiService(
                _marvelConfigurationManager.MarvelPublicKey,
                _marvelConfigurationManager.MarvelPrivateKey,
                _marvelConfigurationManager.MarvelBaseUrl);
        }

        internal ComicService(IComicViewModelMapper comicViewModelMapper, IMarvelApiService marvelApiService) 
        {
            _comicViewModelMapper = comicViewModelMapper;
            _marvelApiService = marvelApiService;
        }

        public List<ComicViewModel> GetComics(int id)
        {
            var result = new List<ComicViewModel>();
            var response = _marvelApiService.GetCharacterComics(id);
            result = response?.Data?.Results?.Select(m => _comicViewModelMapper.Map(m)).ToList();
            return result;
        }
    }
}