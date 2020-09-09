using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.Infrastructure.Validator;
using Atros.Domain.MovieEvaluations.Commands;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.MovieEvaluations.Validators
{
    public class PostMovieEvaluationValidator : AbstractValidator<PostMovieEvaluationCommand>
    {
        public PostMovieEvaluationValidator()
        {
            RuleFor(m => m.MovieId).GreaterThan(0).WithMessage("MovieId 0(sıfır)'dan büyük olmalıdır.");
            RuleFor(m => (int)m.Score).GreaterThan(0).WithMessage("Score 0(sıfır)'dan büyük olmalıdır.");
            RuleFor(m => (int)m.Score).LessThanOrEqualTo(10).WithMessage("Score 10'dan küçük olmalıdır.");
            RuleFor(m => m.Note).NotEmpty().WithMessage("Note zorunlu alandır.").MaximumLength(250);
        }
    }
}
