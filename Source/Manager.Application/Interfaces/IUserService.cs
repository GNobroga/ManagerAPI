using Manager.Application.DTOs;

namespace Manager.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserDTO record);
        Task<UserDTO> UpdateAsync(int id, UserDTO record);
        Task<bool> RemoveAsync(int id);
        Task<List<UserDTO>> FindAllAsync();

        Task<List<UserDTO>> SearchByNameAsync(string name);
        Task<List<UserDTO>> SearchByEmailAsync(string email);

        Task<UserDTO> FindByEmailAsync(string name);

        Task<UserDTO> FindByIdAsync(int id);

    }
}