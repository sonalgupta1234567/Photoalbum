using PhotoAlbum.Api.Models;

namespace PhotoAlbum.WebApi.Services
{
    public interface IPhotoAlbumService
    {
        PhotoAlbumModel GetAllPhotoAlbums();
        PhotoAlbumModel GetAllPhotoAlbumByUserId(int id);
    }
}