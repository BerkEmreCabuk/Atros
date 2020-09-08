using Atros.Domain.MovieEvaluations.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.MovieEvaluations.Commands
{
    public class PostMovieEvaluationCommand : IRequest<MovieEvaluationModel>
    {
        public MovieEvaluationModel MovieEvaluationModel { get; set; }
    }
}
