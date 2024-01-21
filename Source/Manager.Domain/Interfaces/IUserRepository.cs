using Manager.Domain.Entities;

namespace Manager.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> FindByEmail(string email);

        Task<List<User>> SearchByEmail(string email);
    }
}