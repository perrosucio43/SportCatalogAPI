using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Services
{
    public class JwtServices
    {
        private readonly IConfiguration _Config;


        public JwtServices(IConfiguration config){ 
        
        
        _Config = config;
        
        
        
        }

        public string GenerateToken(Guid UserId, string email, string role) {


            var claims = new[] {

       
        new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim ("id", UserId.ToString()),
        new Claim (ClaimTypes.Email, email),
        new Claim(ClaimTypes.Role, role )



       };

            var key = Environment.GetEnvironmentVariable("JWT_KEY")
          ?? _Config["Jwt:Key"];

            if (string.IsNullOrEmpty(key))
                throw new Exception("JWT_KEY no configurada");

            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
             ?? _Config["Jwt:Issuer"];

            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                           ?? _Config["Jwt:Audience"];

            var duration = Environment.GetEnvironmentVariable("JWT_DURATION")
                           ?? _Config["Jwt:DurationInMinutes"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(duration)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }






    }
}
