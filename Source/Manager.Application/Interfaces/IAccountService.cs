using Manager.Application.DTOs;

namespace Manager.Application.Interfaces
{
    public interface IAuthService
    {
       Task<bool> ValidateLoginCredentials(UserDTO record);
    }
}