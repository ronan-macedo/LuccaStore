using AutoFixture.Xunit2;
using LuccaStore.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace LuccaStore.Tests.Core.Application
{
    public class TokenServiceTests
    {
        private readonly IConfiguration _configuration;
        private readonly TokenService _sut;

        public TokenServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "JwtAuth:Audience", "test-audience" },
                { "JwtAuth:Issuer", "test-issuer" },
                { "JwtAuth:Secret", "B81RNBX2XGJ1RFTNW3B2YEKNE8IU445M" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            _sut = new TokenService(_configuration);
        }

        [Theory, AutoData]
        public async Task GetToken_ReturnsToken(IdentityUser user, IList<string> roles)
        {
            // Arrange & Act
            var token = await _sut.GetToken(user, roles);

            // Assert
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);

            Assert.NotNull(token);
            Assert.Equal("test-issuer", decodedToken.Issuer);
        }
    }
}
