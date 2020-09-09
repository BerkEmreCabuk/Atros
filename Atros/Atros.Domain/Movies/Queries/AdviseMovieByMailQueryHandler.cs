using Atros.Common.Enums;
using Atros.Common.Exceptions;
using Atros.Common.Services.Interfaces;
using Atros.Data.Entities;
using Atros.Data.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Movies.Queries
{
    public class AdviseMovieByMailQueryHandler : IRequestHandler<AdviseMovieByMailQuery, string>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMailService _mailService;

        public AdviseMovieByMailQueryHandler(
            IRepository<Movie> repository,
            IMailService mailService
            )
        {
            _repository = repository;
            _mailService = mailService;
        }
        public async Task<string> Handle(AdviseMovieByMailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _repository.FirstOrDefaultAsync(x => x.Status == Status.Active && x.Id == request.MovieId);
            if (movie == null)
                throw new NotFoundException("İlgili film bulunamadı");
            string subject = $"{movie.Title} filmini tavsiye ederim.";
            await _mailService.SendMail(request.EmailAddress, subject);
            return $"{request.EmailAddress} adresine tavsiye maili gönderilmiştir.";
        }
    }
}
