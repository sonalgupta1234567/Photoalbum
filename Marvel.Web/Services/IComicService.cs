using Marvel.Web.Models;
using System.Collections.Generic;

namespace Marvel.Web.Services
{
    public interface IComicService
    {
        List<ComicViewModel> GetComics(int id);
    }
}