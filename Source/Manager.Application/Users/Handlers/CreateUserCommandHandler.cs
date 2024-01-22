using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Commands;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class CreateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<CreateUserCommand, UserDTO>
    {
        public Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return userService.CreateAsync(mapper.Map<UserDTO>(request));
        }
    }

}