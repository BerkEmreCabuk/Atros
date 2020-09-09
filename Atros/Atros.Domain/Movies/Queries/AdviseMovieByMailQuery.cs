using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Movies.Queries
{
    public class AdviseMovieByMailQuery : IRequest<string>
    {
        public AdviseMovieByMailQuery()
        { }
        public string EmailAddress { get; set; }
        public long MovieId { get; set; }
    }
}
