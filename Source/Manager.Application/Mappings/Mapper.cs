using Manager.Domain.Entities.Base;

namespace Manager.Application.Mappings
{
    public class Mapper<TSource, TDestination> : IEntityMapper<TSource, TDestination> where TSource : BaseEntity<int>
    {
        public TDestination MapToDestination(TSource entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            Type destType = typeof(TDestination);
            TDestination destination = Activator.CreateInstance<TDestination>();

            foreach (var property in destType.GetProperties())
            {
                var sourceProperty = entity.GetType().GetProperty(property.Name);

                if (sourceProperty?.PropertyType == property.PropertyType)
                {
                    property.SetValue(destination, sourceProperty.GetValue(entity));
                }
            }

            return destination;
        }

        public List<TDestination> MapToDestination(List<TSource> entities)
        {
            return entities.Select(MapToDestination).ToList();
        }

        public TSource MapToEntity(TDestination destination)
        {
             ArgumentNullException.ThrowIfNull(destination);

            Type destType = typeof(TDestination);
            TSource source = Activator.CreateInstance<TSource>();

            foreach (var property in destType.GetProperties())
            {
                var sourceProperty = destination.GetType().GetProperty(property.Name);

                if (sourceProperty?.PropertyType == property.PropertyType)
                {
                    property.SetValue(source, sourceProperty.GetValue(destination));
                }
            }

            return source;
        }
    }
}