using MediatR;
using System;

namespace Atros.Domain.Users.Queries
{
    public class ExistUserByIdQuery : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
