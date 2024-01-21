using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.Entities.Base
{   
    public abstract class BaseEntity<TKey>
    {   
        [Key]
        public TKey Id { get; protected set; } = default!;

        public abstract bool Validate();
    }
}