using Atros.Domain.MovieEvaluations.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.MovieEvaluations.Queries
{
    public class GetMovieWithDetailQuery : IRequest<MovieDetailModel>
    {
        public int MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}
