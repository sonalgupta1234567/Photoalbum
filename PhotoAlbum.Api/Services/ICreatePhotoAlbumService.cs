using System.Collections.Generic;
using PhotoAlbum.Api.Models;
using PhotoAlbum.Services.Entities;

namespace PhotoAlbum.WebApi.Services
{
    public interface ICreatePhotoAlbumService
    {
        PhotoAlbumModel GetPhotoAlbum(List<Photo> photos, List<Album> albums);
    }
}