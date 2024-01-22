using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Queries;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class GetAllUsersQueryHandler(IUserService userService) : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
           return await userService.FindAllAsync();
        }
    }
}