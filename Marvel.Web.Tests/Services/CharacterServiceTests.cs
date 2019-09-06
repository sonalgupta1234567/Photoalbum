using System.Collections.Generic;
using Marvel.Services;
using Marvel.Services.Models;
using Marvel.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Marvel.Web.Tests.Services
{
    [TestClass]
    public class CharacterServiceTests
    {
        private IMarvelApiService _marvelApiService;
        private ICharacterService _service;

        [TestInitialize]
        public void TestInit()
        {
            _marvelApiService = MockRepository.GenerateMock<IMarvelApiService>();
            _service = new CharacterService(_marvelApiService);
        }

        [TestMethod]
        public void GivenCharacterService_WhenGetCharacterIdIsCalled_ReturnsId()
        {
            //arrange
            var character = GetCharacterResult();
            _marvelApiService.Stub(x => x.GetCharacterByName(Arg<string>.Is.Anything)).Return(character);

            //act
            var result = _service.GetCharacterId("thor");

            //assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GivenCharacterService_WhenGetCharacterIdIsCalled_ReturnsNull()
        {
            //arrange
            var character = GetNoCharacterResult();
            _marvelApiService.Stub(x => x.GetCharacterByName(Arg<string>.Is.Anything)).Return(character);

            //act
            var result = _service.GetCharacterId("thor");

            //assert
            Assert.AreEqual(null, result);
        }

        private CharacterResult  GetCharacterResult()
        {
            return new CharacterResult()
            {
                Data = new DataContainer<Character>()
                {
                    Results = new List<Character>()
                    {
                         new Character()
                         {
                             Id = 1,
                             Name = "thor"
                         }
                    }
                }

            };
        }

        private CharacterResult GetNoCharacterResult()
        {
            return new CharacterResult()
            {
                Data = new DataContainer<Character>()
                {
                    Results = null
                }
            };
        }
    }
}
