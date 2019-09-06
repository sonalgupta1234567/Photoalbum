using System.Collections.Generic;

namespace Marvel.Services.Models
{
    public class Character : MarvelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MarvelSummary> Comics { get; set; }
        public List<StorySummary> Stories { get; set; }
        public List<MarvelSummary> Events { get; set; }
        public List<MarvelSummary> Series { get; set; }
    }
}
