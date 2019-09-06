using Marvel.Services.Models;
using Marvel.Web.Models;

namespace Marvel.Web.Mappers
{
    public interface IComicViewModelMapper
    {
        ComicViewModel Map(Comic comic);
    }
}