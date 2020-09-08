using Atros.Common.Enums;
using Atros.Common.Models;
using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.Movies.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Movies.Queries
{
    public class GetPagedMovieModelQueryHandler : IRequestHandler<GetPagedMovieModelQuery, PagedList<MoviePagedModel>>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public GetPagedMovieModelQueryHandler(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<MoviePagedModel>> Handle(GetPagedMovieModelQuery request, CancellationToken cancellationToken)
        {
            var query = _repository
                .Query()
                .AsNoTracking();

            var totalCount = query.Count();
            var movies = await query
                .Where(x => x.Status == Status.Active)
                .ProjectTo<MoviePagedModel>(_mapper.ConfigurationProvider)
                .Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize).ToListAsync();

            return new PagedList<MoviePagedModel>(movies, request.PageIndex, request.PageSize, totalCount);
        }
    }
}
