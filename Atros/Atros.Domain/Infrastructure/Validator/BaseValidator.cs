using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Domain.Infrastructure.Validator
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : new()
    {
        private readonly IMediator _mediator;

        public BaseValidator(IMediator mediator)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            _mediator = mediator;
        }
    }
}
