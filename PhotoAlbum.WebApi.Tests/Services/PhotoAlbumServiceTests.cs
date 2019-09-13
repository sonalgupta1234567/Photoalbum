using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Services;
using PhotoAlbum.WebApi.Services;
using Rhino.Mocks;
using FluentAssertions;

namespace PhotoAlbum.WebApi.Tests.Services
{
    [TestClass]
    public class PhotoAlbumServiceTests
    {
        private IPhotoAlbumApiService _photoAlbumApiService = MockRepository.GenerateMock<IPhotoAlbumApiService>();
        private ICreatePhotoAlbumService _createPhotoAlbumService = MockRepository.GenerateMock<ICreatePhotoAlbumService>();
        private PhotoAlbumService _service;
        
        [TestInitialize]
        public void Init()
        {
            _service = new PhotoAlbumService(_photoAlbumApiService, _createPhotoAlbumService);
        }

        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumsIsCalled_ThenPhotoAlbumApiServiceGetAlbumsIsCalled()
        {
            //act
            var result = _service.GetAllPhotoAlbums();

            //assert
            _photoAlbumApiService.AssertWasCalled(x => x.GetAlbums());
        }


        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumsIsCalled_ThenPhotoAlbumApiServiceGetPhotosIsCalled()
        {
            //act
            var result = _service.GetAllPhotoAlbums();

            //assert
            _photoAlbumApiService.AssertWasCalled(x => x.GetPhotos());
        }


        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumsIsCalled_ThenCreatePhotoAlbumServiceIsCalled()
        {
            //arrange
            var photos = TestData.GetPhotos();
            var albums = TestData.GetAlbums();
            _photoAlbumApiService.Stub(x => x.GetPhotos()).Return(photos);
            _photoAlbumApiService.Stub(x => x.GetAlbums()).Return(albums);
            //act
            var result = _service.GetAllPhotoAlbums();

            //assert
            _createPhotoAlbumService.AssertWasCalled(x => x.GetPhotoAlbum(photos,albums));
        }


        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumsIsCalled_ReturnsPhotoAlbumModel()
        {
            //arrange
            var photos = TestData.GetPhotos();
            var albums = TestData.GetAlbums();
            var photoalbum = TestData.GetPhotoAlbumModel();
            _photoAlbumApiService.Stub(x => x.GetPhotos()).Return(photos);
            _photoAlbumApiService.Stub(x => x.GetAlbums()).Return(albums);
            _createPhotoAlbumService.Stub(c => c.GetPhotoAlbum(photos, albums)).Return(photoalbum);
            
            //act
            var result = _service.GetAllPhotoAlbums();

            //assert
            result.ShouldBeEquivalentTo(photoalbum);
        }

        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumByUserIdIsCalled_ThenPhotoAlbumApiServiceGetAlbumsByUserIDIsCalled()
        {
            //arrange
            var userId = 1;

            //act
            var result = _service.GetAllPhotoAlbumByUserId(userId);

            //assert
            _photoAlbumApiService.AssertWasCalled(x => x.GetAlbumsByUserId(userId));
        }

        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumByUserIdIsCalled_ThenPhotoAlbumApiServiceGetPhotosIsCalled()
        {
            //act
            var result = _service.GetAllPhotoAlbumByUserId(1);

            //assert
            _photoAlbumApiService.AssertWasCalled(x => x.GetPhotos());
        }

        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumByUserIdIsCalled_ThenCreatePhotoAlbumServiceIsCalled()
        {
            //arrange
            var photos = TestData.GetPhotos();
            var albums = TestData.GetAlbums().Where(c => c.UserId == 1).ToList();
            _photoAlbumApiService.Stub(x => x.GetPhotos()).Return(photos);
            _photoAlbumApiService.Stub(x => x.GetAlbumsByUserId(1)).Return(albums);
           
            //act
            var result = _service.GetAllPhotoAlbumByUserId(1);

            //assert
            _createPhotoAlbumService.AssertWasCalled(x => x.GetPhotoAlbum(photos, albums));
        }

        [TestMethod]
        public void GivenPhotoAlbumService_WhenGetAllPhotoAlbumByUserIdIsCalled_ReturnsPhotoAlbumModel()
        {
            //arrange
            var photos = TestData.GetPhotos();
            var albums = TestData.GetAlbums().Where(c => c.UserId == 1).ToList() ;
            var photoalbum = TestData.GetPhotoAlbumModel();
            _photoAlbumApiService.Stub(x => x.GetPhotos()).Return(photos);
            _photoAlbumApiService.Stub(x => x.GetAlbumsByUserId(1)).Return(albums);
            _createPhotoAlbumService.Stub(c => c.GetPhotoAlbum(photos, albums)).Return(photoalbum);

            //act
            var result = _service.GetAllPhotoAlbumByUserId(1);

            //assert
            result.ShouldBeEquivalentTo(photoalbum);
        }
    }
}