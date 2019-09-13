using System.Collections.Generic;
using System.Linq;
using PhotoAlbum.Api.Models;
using PhotoAlbum.Services.Entities;

namespace PhotoAlbum.WebApi.Services
{
    public class CreatePhotoAlbumService : ICreatePhotoAlbumService
    {
        public PhotoAlbumModel GetPhotoAlbum(List<Photo> photos, List<Album> albums)
        {
            if(photos == null || albums == null)
            {
                return null;
            }
            var photoalbum = from a in albums
                             select new AlbumModel
                             {
                                 Id = a.Id,
                                 UserId = a.UserId,
                                 Title = a.Title,
                                 Photos = (from p in photos
                                           where p.AlbumId == a.Id
                                           select new PhotoModel
                                           {
                                               AlbumId = p.AlbumId,
                                               Id = p.Id,
                                               ThumbnailUrl = p.ThumbnailUrl,
                                               Title = p.Title,
                                               Url =  p.Url
                                           }).ToList()
                             };
            return new PhotoAlbumModel() { Albums = photoalbum.ToList() };
        }
    }
}