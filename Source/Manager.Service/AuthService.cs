using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Domain.Interfaces;
using Manager.Service.Exceptions;

namespace Manager.Service
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<bool> ValidateLoginCredentials(UserDTO record)
        {   
            var user = await userRepository.FindByEmail(record.Email) ?? throw new RuleViolationException("Usuário não cadastrado");
            return BCrypt.Net.BCrypt.Verify(record.Password, user.Password);
        }
    }
}