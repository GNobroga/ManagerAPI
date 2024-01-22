using Manager.Domain.Entities.Base;

namespace Manager.Application.Mappings
{
    public interface IEntityMapper<TEntity, TDestination> where TEntity: BaseEntity<int>
    {
        TDestination MapToDestination(TEntity entity);

        TEntity MapToEntity(TDestination destination);

        List<TDestination> MapToDestination(List<TEntity> entities);
    }
}