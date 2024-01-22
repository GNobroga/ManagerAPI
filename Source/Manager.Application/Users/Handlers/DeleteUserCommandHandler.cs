using Manager.Application.Interfaces;
using Manager.Application.Users.Commands;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class DeleteUserCommandHandler(IUserService userService) : IRequestHandler<DeleteUserCommand, bool>
    {
        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return userService.RemoveAsync(request.Id);
        }
    }
}
