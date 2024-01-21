using Manager.Domain.Entities.Base;
using Manager.Domain.Interfaces;
using Manager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity, TKey>(ApplicationDbContext context) : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected ApplicationDbContext Context => context;

        protected DbSet<TEntity> Entities => context.Set<TEntity>();
    
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetAsync(TKey key)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.Id!.Equals(key));
            return entity;
        }

        public virtual async Task<List<TEntity>> GetAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> RemoveAsync(TKey key)
        {
            var entity = (await GetAsync(key))!;
            Entities.Remove(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Entities.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}