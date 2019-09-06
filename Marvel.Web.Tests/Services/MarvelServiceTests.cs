using Marvel.Web.Models;
using Marvel.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Marvel.Web.Tests.Services
{
    [TestClass]
    public class MarvelServiceTests
    {
        private ICharacterService _characterService;
        private IComicService _comicService;
        private IMarvelService _marvelService;

        [TestInitialize]
        public void TestInit()
        {
            _characterService = MockRepository.GenerateMock<ICharacterService>();
            _comicService = MockRepository.GenerateMock<IComicService>();
            _marvelService = new MarvelService(_characterService, _comicService);
        }

        [TestMethod]
        public void GivenMarvelService_WhenGetComicsIsCalled_WithInvalidCharacterName_ReturnsViewModel_WithNoComics()
        {
            //arrange
            _characterService.Stub(x => x.GetCharacterId(Arg<string>.Is.Anything)).Return(null);

            //act
            var result = _marvelService.GetComics("tr");

            //assert
            Assert.IsInstanceOfType(result, typeof(MarvelViewModel));
            Assert.IsNull(result.Comics);
        }

        [TestMethod]
        public void GivenMarvelService_WhenGetComicsIsCalled_WithCharacterName_ReturnsViewModel_WithComics()
        {
            //arrange
            var list = TestData.GetListOfComicViewModels();
            _characterService.Stub(x => x.GetCharacterId(Arg<string>.Is.Anything)).Return(1);
            _comicService.Stub(x => x.GetComics(Arg<int>.Is.Anything)).Return(list);
         
            //act
            var result = _marvelService.GetComics("thor");

            //assert
            Assert.IsInstanceOfType(result, typeof(MarvelViewModel));
            CollectionAssert.AreEqual(list, result.Comics);
        }       
    }
}
