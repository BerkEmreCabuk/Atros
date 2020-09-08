using Newtonsoft.Json;
using System.Collections.Generic;

namespace Atros.Domain.Movies.Models
{
    public class MovieResponseModel
    {
        public MovieResponseModel()
        {
            Results = new List<MovieModel>();
        }
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int Total_results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public List<MovieModel> Results { get; set; }
    }
}
