using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TryitterWebAPI.Token
{
    public class Generator
    {
        public string Generate(int id)
        {
            var Handler = new JwtSecurityTokenHandler();

            var Descriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(id),
                SigningCredentials = new SigningCredentials(
                     new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constant.Secret)),
                     SecurityAlgorithms.HmacSha256Signature
                     ),
                Expires = DateTime.Now.AddDays(30)
            };

            var token = Handler.CreateToken(Descriptor);

            return Handler.WriteToken(token);
        }

        public ClaimsIdentity AddClaims(int id)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim("Id", id.ToString()));

            return claims;
        }
    }
}