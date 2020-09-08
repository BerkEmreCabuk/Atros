using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.MovieEvaluations.Models
{
    public class MovieDetailModel
    {
        public decimal Popularity { get; set; }
        public int VoteCount { get; set; }
        public long Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public decimal VoteAverage { get; set; }
        public bool Adult { get; set; }
        public bool Video { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
        public int? UserScore { get; set; }
        public double? AverageScore { get; set; }
        public string UserNote { get; set; }
    }
}
