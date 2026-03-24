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

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));



            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _Config["Jwt:Issuer"],
                audience: _Config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_Config["Jwt:DurationInMinutes"])),

                signingCredentials: creds);





            return new JwtSecurityTokenHandler().WriteToken(token);  

        }






    }
}
