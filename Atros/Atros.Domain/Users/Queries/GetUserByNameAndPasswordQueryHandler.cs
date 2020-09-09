using Atros.Common.Enums;
using Atros.Common.Exceptions;
using Atros.Data.Entities;
using Atros.Data.Repository;
using Atros.Domain.Users.Models;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atros.Domain.Users.Queries
{
    public class GetUserByNameAndPasswordQueryHandler : IRequestHandler<GetUserByNameAndPasswordQuery, UserModel>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUserByNameAndPasswordQueryHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByNameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Password == request.Password && x.UserName == request.Username && x.Status == Status.Active);
            if (user == null)
                throw new NotFoundException($"{request.Username} kullanıcısı bulunamadı.");
            return _mapper.Map<User, UserModel>(user);
        }
    }
}
