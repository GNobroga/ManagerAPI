using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Users.Commands;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class UpdateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userService.UpdateAsync(request.Id, mapper.Map<UserDTO>(request));
        }
    }
}