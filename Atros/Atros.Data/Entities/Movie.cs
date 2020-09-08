using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atros.Data.Entities
{
    public class Movie: BaseEntity
    {
        public long Id { get; set; }
        public decimal Popularity { get; set; }
        public int VoteCount { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public decimal VoteAverage { get; set; }
        public bool Adult { get; set; }
        public bool Video { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
        public ICollection<MovieEvaluation> MovieEvaluationEntity { get; set; }
    }
}
