using Manager.Application.DTOs;
using Manager.Application.Users.Commands.Base;
using MediatR;

namespace Manager.Application.Users.Commands
{
    public class UpdateUserCommand(string name, string email, string password, string confirmationPassword) : UserCommand(name, email, password, confirmationPassword)
    {
        public int Id { get; set; }
    }
}