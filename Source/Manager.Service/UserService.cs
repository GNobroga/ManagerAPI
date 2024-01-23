using AutoMapper;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Domain.Entities;
using Manager.Domain.Interfaces;

using Marraia.Notifications.Interfaces;

namespace Manager.Service
{
    public class UserService(IUserRepository userRepository, IMapper mapper, ISmartNotification smartNotification) : IUserService
    {
        public async Task<UserDTO> CreateAsync(UserDTO record)
        {
            var userExists = (await userRepository.FindByEmail(record.Email)) is not null;

            if (userExists)
            {
                smartNotification.NewNotificationConflict("O email informado não está disponível.");
                return default!;
            }

            record.Password = BCrypt.Net.BCrypt.HashPassword(record.Password);

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
            var user = await userRepository.FindByEmail(email);

            if (user is null)
            {
                smartNotification.NewNotificationConflict("Não foi encontrado usuário com o email especificado.");
                return default!;
            }
            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> FindByIdAsync(int id)
        {
            var user = await GetUserOrThrowException(id);
            return mapper.Map<UserDTO>(user);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            await GetUserOrThrowException(id);
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
            if (id != record.Id)
            {
                smartNotification.NewNotificationConflict("O Id passado na rota não bate com o id do objeto passado");
                return default!;
            }

            var user = await GetUserOrThrowException(id);

            if (user is null)
            {
                smartNotification.NewNotificationConflict("Usuário não encontrado.");
                return default!;
            }

            var existUserEmail = await userRepository.FindByEmail(record.Email);

            if (existUserEmail != null && !string.Equals(user.Email, record.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                smartNotification.NewNotificationConflict("O e-mail já está em uso.");
                return default!;
            }

            record.Password = BCrypt.Net.BCrypt.HashPassword(record.Password);
            
            mapper.Map(record, user);

            await userRepository.UpdateAsync(user);

            return mapper.Map<UserDTO>(user);
        }

        private async Task<User?> GetUserOrThrowException(int id)
        {
            return await userRepository.GetAsync(id);
        }
    }
}