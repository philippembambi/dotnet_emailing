using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace First.EmailReminder.Infrastructure.Repositories
{
    public class JwtService : IJwtService
    {
        public readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        
        string IJwtService.GenerateAccessToken(User user)
        {
            var claims = new[]
{
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("role", user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireMinutes = int.Parse(_config["Jwt:ExpireMinutes"]);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        string IJwtService.GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}