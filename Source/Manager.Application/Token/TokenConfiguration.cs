namespace Manager.Application.Token
{
    public class TokenConfiguration
    {
        public string Secret { get; set; } = default!;
        public string Issuer { get; set; } = default!;

        public int HoursToExpires { get; set; } 

        public TokenConfiguration() {}

        public TokenConfiguration(string secret, string issuer, int hoursToExpires)
        {
            Secret = secret;
            Issuer = issuer;
            HoursToExpires = hoursToExpires;
        }
        public void Deconstruct(out string secret, out string issuer, out int hoursToExpires)
        {
            secret = Secret;
            issuer = Issuer;
            hoursToExpires = HoursToExpires;
        }
    }
}