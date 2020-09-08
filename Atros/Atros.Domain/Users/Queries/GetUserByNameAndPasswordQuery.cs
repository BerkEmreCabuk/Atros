using Atros.Domain.Users.Models;
using MediatR;

namespace Atros.Domain.Users.Queries
{
    public class GetUserByNameAndPasswordQuery : IRequest<UserModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
