using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Token;
using Manager.Application.Users.Commands;
using MediatR;

namespace Manager.Application.Users.Handlers
{
    public class LoginUserCommandHandler(IAuthService authService, ITokenGenerator tokenGenerator, IMapper mapper) : IRequestHandler<LoginUserCommand, string>
    {
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            await authService.ValidateLoginCredentials(mapper.Map<UserDTO>(request));
            return tokenGenerator.Generate(request.Email);
        }
    }
}