using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.MovieEvaluations.Models
{
    public class MovieEvaluationModel
    {
        public MovieEvaluationModel()
        {

        }
        public long MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Note { get; set; }
        public byte Score { get; set; }
    }
}
