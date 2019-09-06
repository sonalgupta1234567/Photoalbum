using System;
using System.Collections.Generic;

namespace Marvel.Services.Models
{
    public class MarvelBase
    {
        public int Id { get; set; }
        public string ResourceUri { get; set; }
        public DateTime? Modified { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public List<MarvelUrl> Urls { get; set; }
    }
}