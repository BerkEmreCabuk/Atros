using Atros.Common.Models;
using Atros.Domain.Movies.Models;
using MediatR;

namespace Atros.Domain.Movies.Queries
{
    public class GetPagedMovieModelQuery : IRequest<PagedList<MoviePagedModel>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
