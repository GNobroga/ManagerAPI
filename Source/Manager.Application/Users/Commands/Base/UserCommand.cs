using Manager.Application.DTOs;
using MediatR;

namespace Manager.Application.Users.Commands.Base
{
    public class UserCommand(string name, string email, string password, string confirmationPassword) : IRequest<UserDTO> 
    {
        public string Name => name;
        public string Email => email;

        public string Password => password;

        public string ConfirmationPassword => confirmationPassword;
    }
}