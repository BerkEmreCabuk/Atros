using Newtonsoft.Json;
using System;

namespace Atros.Domain.Movies.Models
{
    public class MovieModel
    {
        public decimal Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
        public long Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
        public bool Adult { get; set; }
        public bool Video { get; set; }

        [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
    }
}
