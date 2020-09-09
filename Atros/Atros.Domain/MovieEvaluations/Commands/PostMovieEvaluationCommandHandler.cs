using Atros.Common.Enums;
using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.MovieEvaluations.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.MovieEvaluations.Commands
{
    public class PostMovieEvaluationCommandHandler : IRequestHandler<PostMovieEvaluationCommand, MovieEvaluationModel>
    {
        private readonly IRepository<MovieEvaluation> _repository;
        private readonly IMapper _mapper;
        public PostMovieEvaluationCommandHandler(
            IRepository<MovieEvaluation> repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MovieEvaluationModel> Handle(PostMovieEvaluationCommand request, CancellationToken cancellationToken)
        {
            var movieEvaluation = await _repository.FirstOrDefaultAsync(x =>
              x.Status == Status.Active &&
              x.MovieId == request.MovieId &&
              x.UserId == request.UserId);
            if(movieEvaluation!=null)
            {
                movieEvaluation.Score = request.Score;
                movieEvaluation.Note = request.Note;
                _repository.Modify(movieEvaluation);
            }
            else
            {
                movieEvaluation = _mapper.Map<MovieEvaluationModel, MovieEvaluation>(request);
                _repository.Add(movieEvaluation);
            }
            
            await _repository.SaveChangesAsync();
            return request;
        }
    }
}
