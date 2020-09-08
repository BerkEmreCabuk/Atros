using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.Movies.Models;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Movies.Commands
{
    public class BulkSynchronizeCommandHandler : IRequestHandler<BulkSynchronizeCommand, int>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;
        public BulkSynchronizeCommandHandler(
            IRepository<Movie> repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(BulkSynchronizeCommand request, CancellationToken cancellationToken)
        {
            var movies = _mapper.Map<List<MovieModel>, List<Movie>>(request.MovieModels);
            return await _repository.BulkSynchronizeAsync(movies);
        }
    }
}
