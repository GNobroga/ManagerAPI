namespace Manager.Application.Token
{
    public interface ITokenGenerator
    {
        string Generate(string email);
    }
}