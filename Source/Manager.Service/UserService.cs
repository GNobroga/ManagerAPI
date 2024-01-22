using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Domain.Interfaces;
using Manager.Service.Exceptions;

namespace Manager.Service
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<UserDTO> CreateAsync(UserDTO record)
        {
         
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> FindByEmailAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> SearchByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDTO>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateAsync(int id, UserDTO record)
        {
            throw new NotImplementedException();
        }
    }
}