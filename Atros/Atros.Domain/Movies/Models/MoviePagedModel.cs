using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Movies.Models
{
    public class MoviePagedModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
    }
}
