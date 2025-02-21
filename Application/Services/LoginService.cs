using ConstructionProjectManagement.Application.DTOs;
using ConstructionProjectManagement.Domain.Entities;
using ConstructionProjectManagement.Domain.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;

namespace ConstructionProjectManagement.Application.Services
{
    public class LoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _repository.GetUserByEmailAsync(request.Email);
            if (user == null || user.Password != request.Password)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            //var token = GenerateJwtToken(user);
            return new LoginResponse { Id = user.Id };
        }
        //private string GenerateJwtToken(Users user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var key = Encoding.ASCII.GetBytes("1234");

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, user.Email) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
