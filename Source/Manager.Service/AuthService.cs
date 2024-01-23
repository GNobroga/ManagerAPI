using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Domain.Interfaces;
using Marraia.Notifications.Interfaces;

namespace Manager.Service
{
    public class AuthService(IUserRepository userRepository, ISmartNotification smartNotification) : IAuthService
    {
        public async Task<bool> ValidateLoginCredentials(UserDTO record)
        {   
            var user = await userRepository.FindByEmail(record.Email);

            if (user is null)
            {
                smartNotification.NewNotificationConflict("Usuário não está cadastrado.");
                return default!;
            }
            return BCrypt.Net.BCrypt.Verify(record.Password, user.Password);
        }
    }
}