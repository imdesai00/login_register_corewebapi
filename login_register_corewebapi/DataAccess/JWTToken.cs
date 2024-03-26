using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace login_register_corewebapi.DataAccess
{
    public interface IJwttoken
    {
        string GenerateToken(string username);
        string GenerateReferenceToken(string jwttoken);
        string GetJwtToken(string referenceToken);
    }
    public class JWTToken : IJwttoken
    {
        private readonly Dictionary<string, string> _tokenStore = new Dictionary<string, string>();
        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Your Key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                Issuer = "Your Issuer",
                Audience = "Your Audience",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateReferenceToken(string jwtToken)
        {
            var referenceToken = Guid.NewGuid().ToString();
            _tokenStore[referenceToken] = jwtToken;
            return referenceToken;
        }
        public string GetJwtToken(string referenceToken)
        {
            if (_tokenStore.ContainsKey(referenceToken))
            {
                return _tokenStore[referenceToken];
            }
            return null;
        }
    }
}
