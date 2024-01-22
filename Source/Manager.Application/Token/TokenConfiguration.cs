namespace Manager.Application.Token
{
    public class TokenConfiguration(string secret, string issuer, int hoursToExpires)
    {
        public string Secret { get; set; } = secret;

        public string Issuer { get; set; } = issuer;

        public int HoursToExpires { get; set; } = hoursToExpires;


        public void Deconstruct(out string secret, out string issuer, out int hoursToExpires)
        {
            secret = Secret;
            issuer = Issuer;
            hoursToExpires = HoursToExpires;
        }
    }
}