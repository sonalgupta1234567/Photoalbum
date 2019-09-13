using System.Web.Http;
using PhotoAlbum.Api.Models;
using PhotoAlbum.WebApi.Services;

namespace PhotoAlbum.Api.Controllers
{
    public class PhotoAlbumController : ApiController
    {
        private readonly IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController()
        {
            _photoAlbumService = new PhotoAlbumService();
        }

        internal PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;
        }

        // GET api/photoalbum
        public PhotoAlbumModel Get()
        {
            return _photoAlbumService.GetAllPhotoAlbums();
        }

        // GET api/photoalbum/5
        public PhotoAlbumModel Get(int id)
        {
            return _photoAlbumService.GetAllPhotoAlbumByUserId(id);
        }
    }
}
