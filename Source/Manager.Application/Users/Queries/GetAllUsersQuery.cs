using Manager.Application.DTOs;
using MediatR;

namespace Manager.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDTO>> {}
}