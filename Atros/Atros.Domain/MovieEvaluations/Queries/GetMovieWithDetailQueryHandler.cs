using Atros.Common.Enums;
using Atros.Common.Exceptions;
using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.MovieEvaluations.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.MovieEvaluations.Queries
{
    public class GetMovieWithDetailQueryHandler : IRequestHandler<GetMovieWithDetailQuery, MovieDetailModel>
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<MovieEvaluation> _movieEvaluationRepository;
        private readonly IMapper _mapper;
        public GetMovieWithDetailQueryHandler(
            IRepository<Movie> movieRepository,
            IRepository<MovieEvaluation> movieEvaluationRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _movieEvaluationRepository = movieEvaluationRepository;
            _mapper = mapper;
        }
        public async Task<MovieDetailModel> Handle(GetMovieWithDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync(x => x.Status == Status.Active && x.Id == request.MovieId);
            if (movie == null)
                throw new NotFoundException("Film bulunamadı.");
            var movieDetail = _mapper.Map<Movie, MovieDetailModel>(movie);

            movieDetail.AverageScore = await _movieEvaluationRepository
                .Query()
                .AsNoTracking()
                .Where(x =>
                    x.MovieId == request.MovieId &&
                    x.Status == Status.Active)
                .AverageAsync(x => x.Score);
            var movieEvaluation = await _movieEvaluationRepository.FirstOrDefaultAsync(x =>
             x.Status == Status.Active &&
             x.MovieId == request.MovieId &&
             x.UserId == request.UserId);
            movieDetail.UserScore = movieEvaluation?.Score;
            movieDetail.UserNote = movieEvaluation?.Note;

            return movieDetail;
        }
    }
}
