using Common.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealEstate.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly TokenManagement _tokenManagement;
        public AuthenticationService(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }
        public async Task<string> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_tokenManagement.JwtExpireDays));

            var token = new JwtSecurityToken(
                _tokenManagement.JwtIssuer,
                _tokenManagement.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwttoken;
        }
    }
}
