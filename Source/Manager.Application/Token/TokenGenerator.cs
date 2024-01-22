using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Application.Token
{
    public class TokenGenerator(IOptions<TokenConfiguration> tokenConfiguration) : ITokenGenerator
    {
        public string Generate(string email)
        {
            var (secret, issuer, expires) = tokenConfiguration.Value;
   
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(secret));
            
            JwtSecurityToken jwtSecurityToken = new(
                issuer: issuer,
                expires: DateTime.Now.AddHours(expires),
                claims: [ new Claim(JwtRegisteredClaimNames.Sub, email) ],
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            
            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}