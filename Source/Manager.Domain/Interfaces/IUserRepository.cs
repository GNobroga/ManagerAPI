using Manager.Domain.Entities;

namespace Manager.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<List<User>> SearchByNameAsync(string name);
        Task<List<User>> SearchByEmailAsync(string email);

        Task<User?> FindByEmail(string email);
    }
}