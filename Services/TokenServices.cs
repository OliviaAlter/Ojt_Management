using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
           
            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, account.Roles.RoleName),
                new(ClaimTypes.Email, account.Email),
                new(ClaimTypes.NameIdentifier, account.AccountId.ToString())
            };
            
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:NotTokenKeyForSureSourceTrustMeDude"]));

            var credential = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential);

            return tokenHandler.WriteToken(token);
        }
    }
}