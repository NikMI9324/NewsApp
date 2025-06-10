using Microsoft.Extensions.Configuration;
using NewsApp.Backend.User.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using NewsApp.Backend.User.Domain.Interfaces;
using System;
using System.Text;
using System.Security.Claims;
using System.Data;

namespace NewsApp.Backend.User.Infrastructure
{
    public sealed class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _configuration;
        TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(UserModel user)
        {
            string secretKey = _configuration["Jwt:Secret"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
                    ]),
                Expires = DateTime.UtcNow.AddMinutes(Int32.Parse(_configuration["Jwt:ExpirationInMinutes"])),
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
                
            };
            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
