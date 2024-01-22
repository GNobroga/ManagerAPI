using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Domain.Entities;
using Manager.Domain.Interfaces;
using Manager.Service.Exceptions;

namespace Manager.Service
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        public async Task<UserDTO> CreateAsync(UserDTO record)
        {
            var userExists = (await userRepository.FindByEmail(record.Email)) is not null;

            if (userExists)
                throw new RuleViolationException("O email informado não está disponível.");

            var user = mapper.Map<User>(record);

            return mapper.Map<UserDTO>(await userRepository.CreateAsync(user));
        }

        public async Task<List<UserDTO>> FindAllAsync()
        {
            var users = await userRepository.GetAsync();
            return mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> FindByEmailAsync(string email)
        {
            var user = await userRepository.FindByEmail(email) ?? throw new RuleViolationException("O email não existe.");
            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> FindByIdAsync(int id)
        {
            var user = await userRepository.GetAsync(id) ?? throw new RuleViolationException("O usuário não existe.");
            return mapper.Map<UserDTO>(user);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await userRepository.RemoveAsync(id);
        }

        public async Task<List<UserDTO>> SearchByEmailAsync(string email)
        {
            var users = await userRepository.SearchByNameAsync(email);
            return mapper.Map<List<UserDTO>>(users);
        }

        public async Task<List<UserDTO>> SearchByNameAsync(string name)
        {
            var users = await userRepository.SearchByNameAsync(name);
            return mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> UpdateAsync(int id, UserDTO record)
        {
            var user = await userRepository.GetAsync(id) ?? throw new RuleViolationException("O usuário não existe.");
            
            mapper.Map(record, user);

            await userRepository.UpdateAsync(user);

            return mapper.Map<UserDTO>(user);
        }
    }
}