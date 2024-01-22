using Manager.Application.DTOs;
using MediatR;

namespace Manager.Application.Users.Commands.Base
{
    public abstract class BaseUserCommand(UserDTO userDTO) : IRequest<UserDTO>
    {
        public UserDTO UserDTO => userDTO;
    }
}