using Manager.Application.DTOs;
using Manager.Application.Users.Commands.Base;
using MediatR;

namespace Manager.Application.Users.Commands
{
    public class CreateUserCommand(UserDTO userDTO) : BaseUserCommand(userDTO)
    {}
}