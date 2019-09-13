using System.Collections.Generic;
using PhotoAlbum.Api.Models;
using PhotoAlbum.Services.Entities;

namespace PhotoAlbum.WebApi.Tests
{
    public class TestData
    {
        public static List<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo()
                {
                  AlbumId = 1,
                  Id = 2,
                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                  Url =  "https://via.placeholder.com/600/f66b97",
                  Title = "test1"
                },
                new Photo()
                {
                  AlbumId = 1,
                  Id = 3,
                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                  Url =  "https://via.placeholder.com/600/f66b97",
                  Title = "test2"
                }
            };
        }

        public static List<Album> GetAlbums()
        {
            return new List<Album>()
            {
                new Album()
                {
                  UserId = 1,
                  Id = 1,
                  Title = "test1"
                },
                new Album()
                {
                  UserId = 2,
                  Id = 3,
                  Title = "test2"
                }
            };
        }

        public static PhotoAlbumModel GetPhotoAlbumModel()
        {
            return new PhotoAlbumModel()
            {
                Albums = new List<AlbumModel>()
                {
                    new AlbumModel()
                    {
                        Id = 1,
                        Title = "test1",
                        UserId = 1,
                        Photos = new List<PhotoModel>()
                        {
                            new PhotoModel()
                            {
                                  AlbumId = 1,
                                  Id = 2,
                                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                                  Url =  "https://via.placeholder.com/600/f66b97",
                                  Title = "test1"
                            },
                            new PhotoModel()
                            {
                                  AlbumId = 1,
                                  Id = 3,
                                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                                  Url =  "https://via.placeholder.com/600/f66b97",
                                  Title = "test2"
                            }
                        }
                    },
                    new AlbumModel()
                    {
                          UserId = 2,
                          Id = 3,
                          Title = "test2",
                          Photos = new List<PhotoModel>()
                    }
                }
            };
        }
    }
}
