using LoginExample.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LoginExample.WebApi.Services
{
    public class JwtService
    {
        private readonly IConfiguration Configuration;

        public JwtService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public LoginResponseDTO CreateToken(IdentityUser user)
        {
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Configuration["JWT:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            SigningCredentials signingCredentials = new(
                new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(Configuration["JWT:Key"])
                ),
                SecurityAlgorithms.HmacSha256
                );
            var token = CreateJwtToken(Claims, signingCredentials);
            return new LoginResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials) =>
            new JwtSecurityToken
            (
                Configuration["JWT:Issuer"],
                Configuration["JWT:Audience"],
                claims,
                signingCredentials: credentials
            );
    }
}
