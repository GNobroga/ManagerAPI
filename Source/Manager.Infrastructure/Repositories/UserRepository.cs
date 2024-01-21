using Manager.Domain.Entities;
using Manager.Domain.Interfaces;
using Manager.Infrastructure.Context;
using Manager.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository<User, int>(context), IUserRepository
    {
        public async Task<User?> FindByEmail(string email)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var users = await Entities.Where(x => x.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
            return users;
        }
    }
}