using Atros.Common.Enums;
using Atros.Data.Entities;
using Atros.Data.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Users.Queries
{
    public class ExistUserByIdQueryHandler : IRequestHandler<ExistUserByIdQuery, bool>
    {
        private readonly IRepository<User> _repository;

        public ExistUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ExistUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ExistAsync(x => x.Id == request.Id && x.Status == Status.Active);
        }
    }
}
