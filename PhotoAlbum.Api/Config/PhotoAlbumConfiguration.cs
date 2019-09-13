using System.Configuration;

namespace PhotoAlbum.Api.Config
{
    public class PhotoAlbumConfiguration
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];      
    }
}