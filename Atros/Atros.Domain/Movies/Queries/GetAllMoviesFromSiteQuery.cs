using Atros.Domain.Movies.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Movies.Queries
{
    public class GetAllMoviesFromSiteQuery : IRequest<List<MovieModel>>
    {
    }
}
