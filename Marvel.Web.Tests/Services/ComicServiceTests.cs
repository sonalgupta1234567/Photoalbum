using System.Collections.Generic;
using Marvel.Services;
using Marvel.Services.Models;
using Marvel.Web.Mappers;
using Marvel.Web.Models;
using Marvel.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Marvel.Web.Tests.Services
{
    [TestClass]
    public class ComicServiceTests
    {
        private IMarvelApiService _marvelApiService;
        private IComicViewModelMapper _comicViewModelMapper;
        private IComicService _comicService;

        [TestInitialize]
        public void TestInit()
        {
            _marvelApiService = MockRepository.GenerateMock<IMarvelApiService>();
            _comicViewModelMapper = MockRepository.GenerateMock<IComicViewModelMapper>();
        }

        [TestMethod]
        public void GivenComicService_WhenGetComicsIsCalled_WithCharacterId_ReturnsListOfComicViewModel()
        {
            //arrange
            var comicResult = GetComicResult();
            _marvelApiService.Stub(x => x.GetCharacterComics(Arg<int>.Is.Anything)).Return(comicResult);
            _comicViewModelMapper.Stub(x => x.Map(Arg<Comic>.Is.Anything)).Return(new ComicViewModel());
            _comicService = new ComicService( _comicViewModelMapper, _marvelApiService);
            
            //act
            var result = _comicService.GetComics(1);

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ComicViewModel>));
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void GivenComicService_WhenGetComicsIsCalled_WithCharacterId_ReturnsNullIfNoComicsExists()
        {
            //arrange
            var comicResult = GetNoComicResult();
            _marvelApiService.Stub(x => x.GetCharacterComics(Arg<int>.Is.Anything)).Return(comicResult);
            _comicViewModelMapper.Stub(x => x.Map(Arg<Comic>.Is.Anything)).Return(new ComicViewModel());
            _comicService = new ComicService(_comicViewModelMapper, _marvelApiService);
         
            //act
            var result = _comicService.GetComics(1);

            //assert
            Assert.IsNull(result);
        }

        private ComicResult GetComicResult()
        {
            return new ComicResult()
            {
                Data = new DataContainer<Comic>()
                {
                    Results = TestData.GetListOfComics()
                }
            };
        }

        private ComicResult GetNoComicResult()
        {
            return new ComicResult()
            {
                Data = new DataContainer<Comic>()
                {
                    Results = null
                }
            };
        }
    }
}
