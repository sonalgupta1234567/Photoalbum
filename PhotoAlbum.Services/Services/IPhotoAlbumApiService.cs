using System.Collections.Generic;
using PhotoAlbum.Services.Entities;

namespace PhotoAlbum.Services
{
    public interface IPhotoAlbumApiService
    {
        List<Photo> GetPhotos();
        List<Album> GetAlbums();
        List<Album> GetAlbumsByUserId(int id);
    }
}