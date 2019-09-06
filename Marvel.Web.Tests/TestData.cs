using Marvel.Services.Models;
using Marvel.Web.Models;
using System.Collections.Generic;

namespace Marvel.Web.Tests
{
    public class TestData
    {
        public static List<ComicViewModel> GetListOfComicViewModels()
        {
            return new List<ComicViewModel>()
                {
                    new ComicViewModel()
                    {
                        Title = "spider-man",
                        Description = "spider-man new comic",
                        Thumbnail = "http://marvel.jpg"

                    },
                    new ComicViewModel()
                    {
                        Title = "thor",
                        Description = "thor new movie",
                        Thumbnail = "http://marvel.jpg"
                    }
                };
        }
        public static List<Comic> GetListOfComics()
        {
            return new List<Comic>()
            {
                new Comic()
                {
                    Title = "spider-man",
                    Description = "spider-man new comic",
                    Thumbnail = new MarvelImage()
                    {
                        Path = "http://spider",
                        Extension = "jpg"
                    }
                },
                new Comic()
                {
                    Title = "thor",
                    Description = "thor new movie",
                    Thumbnail = new MarvelImage()
                    {
                        Path = "http://thor",
                        Extension = "png"
                    }
                }
            };
        }
    }
}
