using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.WebApi.Services;
using FluentAssertions;
using PhotoAlbum.Api.Models;

namespace PhotoAlbum.WebApi.Tests.Services
{
    [TestClass]
    public class CreatePhotoAlbumServiceTests
    {
        private CreatePhotoAlbumService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new CreatePhotoAlbumService();
        }
        [TestMethod]
        public void GivenCreatePhotoAlbumService_WhenGetPhotoAlbumIsCalled_WithPhotosAndAlbums_ReturnPhotoAlbumModel()
        {
            //arrange
            var albums = TestData.GetAlbums();
            var photos = TestData.GetPhotos();
            var expected = TestData.GetPhotoAlbumModel();

            //act
            var result = _service.GetPhotoAlbum(photos, albums);

            //assert
            result.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GivenCreatePhotoAlbumService_WhenGetPhotoAlbumIsCalled_WithPhotosIsNull_ReturnNull()
        {
            //arrange
            var albums = TestData.GetAlbums();
            var expected = TestData.GetPhotoAlbumModel();

            //act
            var result = _service.GetPhotoAlbum(null, albums);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenCreatePhotoAlbumService_WhenGetPhotoAlbumIsCalled_WithAlbumsIsNull_ReturnNull()
        {
            //arrange
            var photos = TestData.GetPhotos();
            var expected = TestData.GetPhotoAlbumModel();

            //act
            var result = _service.GetPhotoAlbum(photos, null);

            //assert
            Assert.IsNull(result);
        }
    }
}