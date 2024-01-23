using MediatR;

namespace Manager.Application.Users.Commands
{
    public class LoginUserCommand(string email, string password) : IRequest<string>
    {
        public string Email => email;
        public string Password => password;
    }
}