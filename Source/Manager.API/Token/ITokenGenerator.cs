namespace Manager.API.Token
{
    public interface ITokenGenerator
    {
        string Generate(int userId);
    }
}