using MediatR;

namespace Manager.Application.Users.Commands
{
    public class DeleteUserCommand(int id) : IRequest<bool>
    {
        public int Id => id;
    }
}