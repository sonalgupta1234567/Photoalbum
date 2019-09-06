using System.Collections.Generic;

namespace Marvel.Web.Models
{
    public class MarvelViewModel
    {
        public string CharacterName { get; set; }
        public List<ComicViewModel> Comics { get; set; }
        public string Message { get; internal set; }
    }
}