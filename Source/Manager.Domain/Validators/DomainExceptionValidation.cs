namespace Manager.Domain.Validators
{

    public class DomainValidationException : Exception
    {
        public List<string> Errors { get; private set; } = [];

        public DomainValidationException(string message, List<string> errors) : base(message) {
            Errors = errors;
        }

        public DomainValidationException(string message) : base(message) {}

        public DomainValidationException(string message, Exception innerException) : base(message, innerException) {}

    }
}