namespace Manager.API.Token
{
    public class TokenConfiguration(string secret, string issuer, int hoursToExpires)
    {
        public string Secret => secret;

        public string Issuer => issuer;

        public int HoursToExpires => hoursToExpires;


        public void Deconstruct(out string secret, out string issuer, out int hoursToExpires)
        {
            secret = Secret;
            issuer = Issuer;
            hoursToExpires = HoursToExpires;
        }
    }
}