using Manager.Domain.Entities.Base;

namespace Manager.Domain.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity: BaseEntity<TKey>
    {   
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> RemoveAsync(TKey key);

        Task<TEntity?> GetAsync(TKey key);

        Task<List<TEntity>> GetAsync();
    }
}