using Microsoft.Extensions.Configuration;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.Application.Dtos.Requests;

namespace SurveyApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = Convert.ToBase64String(hmac.Key);
            passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public string GenerateToken(User user)
        {
            var key = _configuration.GetSection("JWT:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                notBefore: DateTime.Now,
                signingCredentials: creadentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return token;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userService.GetUserByUserNameAsync(request.UserName);

            ArgumentNullException.ThrowIfNull(user,"Kullanıcı Bulunamadı.");

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Kullanııc Bilgileri Doğrulanamadı");
            }

            var token = GenerateToken(user);
            var response = new LoginResponse
            {
                Token = token,
                RefreshToken = user.RefreshToken
            };
            return response;
        }
        public async Task<LoginResponse> RefreshTokenAsync(string refreshToken, Guid userId)
        {

            var user = await _userService.GetUserByRefreshTokenAndUserIdAsync(refreshToken, userId);

            if (user is null)
            {
                return null;
            }

            var token = GenerateToken(user);
            var response = new LoginResponse
            {
                Token = token,
                RefreshToken = user.RefreshToken
            };
            return response;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RefreshToken = Guid.NewGuid().ToString()
            };
            await _userService.AddAsync(user);
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(Convert.FromBase64String(passwordSalt));

            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return passwordHash.Equals(computedHash);
        }
    }
}
