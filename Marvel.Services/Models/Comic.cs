using System.Collections.Generic;

namespace Marvel.Services.Models
{
    public class Comic 
    {
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Upc { get; set; }
        public string DiamondCode { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public List<TextObject> TextObjects { get; set; }
        public MarvelSummary Series { get; set; }
        public List<MarvelSummary> Variants { get; set; }
        public List<MarvelSummary> Collections { get; set; }
        public List<MarvelSummary> CollectedIssues { get; set; }
        public List<ComicDate> Dates { get; set; }
        public List<ComicPrice> Prices { get; set; }
        public List<MarvelImage> Images { get; set; }
        public List<CreatorSummary> Creators { get; set; }
        public List<CharacterSummary> Characters { get; set; }
        public List<StorySummary> Stories { get; set; }
        public List<MarvelSummary> Events { get; set; }
    }
}