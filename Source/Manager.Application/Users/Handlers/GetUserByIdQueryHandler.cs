using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Queries;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class GetUserByIdQueryHandler(IUserService userService) : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        public Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return userService.FindByIdAsync(request.Id);
        }
    }
}