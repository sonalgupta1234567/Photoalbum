using Marvel.Web.Models;
using Marvel.Web.Services;
using System.Linq;
using System.Web.Mvc;

namespace Marvel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMarvelService _marvelService;
        public HomeController()
        {
            _marvelService = new MarvelService();
        }

        public HomeController(IMarvelService marvelService)
        {
            _marvelService = marvelService;
        }
        public ActionResult Index()
        {
            return View(new MarvelViewModel());
        }

        [HttpPost]
        public ActionResult Index(string characterName)
        {
            var model = _marvelService.GetComics(characterName);
            if(model.Comics == null || !model.Comics.Any())
            {
                model.Message = "Sorry no comics found try again!";
            }
            return View(model);
        }
    }
}