using Manager.Application.DTOs;
using MediatR;

namespace Manager.Application.Users.Queries
{
    public class GetUserByIdQuery(int id) : IRequest<UserDTO>
    {
        public int Id => id;
    }
}