using PhotoAlbum.Api.Config;
using PhotoAlbum.Api.Models;
using PhotoAlbum.Services;

namespace PhotoAlbum.WebApi.Services
{
    public class PhotoAlbumService :IPhotoAlbumService
    {
        private readonly IPhotoAlbumApiService _photoAlbumApiService;
        private readonly ICreatePhotoAlbumService _createPhotoAlbumService;

        public PhotoAlbumService()
        {
            _photoAlbumApiService = new PhotoAlbumApiService(PhotoAlbumConfiguration.BaseUrl);
            _createPhotoAlbumService = new CreatePhotoAlbumService();
        }

        internal PhotoAlbumService(IPhotoAlbumApiService photoAlbumService, ICreatePhotoAlbumService createPhotoAlbumService)
        {
            _photoAlbumApiService = photoAlbumService;
            _createPhotoAlbumService = createPhotoAlbumService;
        }

        public PhotoAlbumModel GetAllPhotoAlbums()
        {
            var albums = _photoAlbumApiService.GetAlbums();
            var photos = _photoAlbumApiService.GetPhotos();
            return _createPhotoAlbumService.GetPhotoAlbum(photos, albums);
        }

        public PhotoAlbumModel GetAllPhotoAlbumByUserId(int id)
        {
            var albums = _photoAlbumApiService.GetAlbumsByUserId(id);
            var photos = _photoAlbumApiService.GetPhotos();
            return _createPhotoAlbumService.GetPhotoAlbum(photos, albums);
        }
    }
}