using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Api.Controllers;
using PhotoAlbum.WebApi.Services;
using Rhino.Mocks;
using FluentAssertions;

namespace PhotoAlbum.WebApi.Tests.Controller
{
    [TestClass]
    public class PhotoAlbumControllerTests
    {
        private PhotoAlbumController _controller;
        private IPhotoAlbumService _photoAlbumService = MockRepository.GenerateMock<IPhotoAlbumService>();

        [TestInitialize]
        public void Init()
        {
            _controller = new PhotoAlbumController(_photoAlbumService);
        }

        [TestMethod]
        public void GivenPhotoAlbumController_WhenGetIsCalled_ReturnsPhotoAlbumModel()
        {
            //arrange
            var photoAlbum = TestData.GetPhotoAlbumModel();
            _photoAlbumService.Stub(c => c.GetAllPhotoAlbums()).Return(photoAlbum);

            //act
            var result = _controller.Get();

            //assert
            result.ShouldBeEquivalentTo(photoAlbum);
        }

        [TestMethod]
        public void GivenPhotoAlbumController_WhenGetIsCalled_WithId_ReturnsPhotoAlbumModel()
        {
            //arrange
            var userId = 1;
            var photoAlbum = TestData.GetPhotoAlbumModel();
            _photoAlbumService.Stub(c => c.GetAllPhotoAlbumByUserId(userId)).Return(photoAlbum);

            //act
            var result = _controller.Get(userId);

            //assert
            result.ShouldBeEquivalentTo(photoAlbum);
        }
    }
}