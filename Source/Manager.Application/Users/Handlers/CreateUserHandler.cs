using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Commands;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class CreateUserHandler(IUserService userService) : IRequestHandler<CreateUserCommand, UserDTO>
    {
        public Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("dsd");
        }
    }

}