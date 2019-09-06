using Marvel.Services.Models;
using Marvel.Web.Mappers;
using Marvel.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marvel.Web.Tests.Mappers
{
    [TestClass]
    public class ComicViewModelMapperTests
    {
        [TestMethod]
        public void GivenComicViewModelMapper_WhenMapIsCalled_WithComicModel_ReturnComicViewModel()
        {
            //arrange
            ComicViewModelMapper mapper = new ComicViewModelMapper();
            var comic = new Comic()
            {
                Thumbnail = new MarvelImage()
                {
                    Extension = "jpg",
                    Path = "http://marvel"
                },
                Title = "thor new comic",
                Description = "desc thor new comic"
            };

            //act
            var result = mapper.Map(comic);

            //assert

            Assert.IsInstanceOfType(result, typeof(ComicViewModel));
            Assert.AreEqual(comic.Title, result.Title);
            Assert.AreEqual(comic.Description, result.Description);
            Assert.AreEqual("http://marvel.jpg", result.Thumbnail);
        }
    }
}
