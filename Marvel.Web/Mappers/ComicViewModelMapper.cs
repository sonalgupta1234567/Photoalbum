using Marvel.Services.Models;
using Marvel.Web.Models;
using System.Linq;

namespace Marvel.Web.Mappers
{
    public class ComicViewModelMapper : IComicViewModelMapper
    {
        public ComicViewModel Map(Comic comic)
        {
            return new ComicViewModel()
            {
                Thumbnail = string.Format("{0}.{1}", comic.Thumbnail.Path, comic.Thumbnail.Extension),            
                Title = comic.Title,
                Description = comic.Description
            };
        }
    }
}