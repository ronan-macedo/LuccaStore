using LuccaStore.Core.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LuccaStore.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _jwtKey;
        private readonly string _jwtAudience;
        private readonly string _jwtIssuer;

        public TokenService(IConfiguration configuration)
        {
            _jwtAudience = configuration.GetValue<string>("JwtAuth:Audience");
            _jwtIssuer = configuration.GetValue<string>("JwtAuth:Issuer");
            _jwtKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtAuth:Secret"));
        }

        public Task<string> GetToken(IdentityUser user, IList<string>? userRoles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (userRoles != null)
            {
                foreach (var useRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, useRole));
                }
            }

            var subject = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtIssuer,
                Audience = _jwtAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtKey),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Subject = subject,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(2),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
