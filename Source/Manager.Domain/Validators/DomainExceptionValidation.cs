namespace Manager.Domain.Validators
{
    public class DomainValidationException(string message) : Exception(message)
    {}
}