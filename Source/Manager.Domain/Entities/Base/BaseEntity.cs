using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.Entities.Base
{   
    public abstract class BaseEntity<TKey>
    {   
        [Key]
        public TKey Id { get; protected set; } = default!;

        internal List<string> _errors = [];

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}