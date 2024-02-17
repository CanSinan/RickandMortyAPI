using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Repositories.AuthenticationRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.AuthenticationServices
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private IConfiguration _configuration;
        private readonly string _signinKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthenticationServices(RickAndMortyDbContext context, IConfiguration configuration, IAuthenticationRepository authenticationRepository)
        {
            _configuration = configuration;
            _signinKey = configuration["JWT:Key"];
            _issuer = configuration["JWT:Issuer"];
            _audience = configuration["JWT:Audience"];
            _authenticationRepository = authenticationRepository;
        }

        public async Task<User> RegisterAsync(User user)
        {
            user.Password = await PasswordHashAsync(user.Password);
            var userRegister = await _authenticationRepository.RegisterAsync(user);
            return userRegister;
        }

        public async Task<User> LoginAsync(User user)
        {
            var hashedPassword = await PasswordHashAsync(user.Password);
            user.Password = hashedPassword;
            var userexist = await _authenticationRepository.LoginAsync(user);
            if (userexist != null)
            {
                userexist.AccessToken = await GenerateNewJsonWebToken(userexist.UserName, userexist.Role.RoleName);
                userexist.AccessTokenCreateDate = DateTime.Now;
                await _authenticationRepository.SaveAsync();
                return userexist;

            }
            return null;
        }

        private async Task<string> GenerateNewJsonWebToken(string userName, string role)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            };

            string signinKey = _signinKey;
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var tokenObject = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.UtcNow.AddMinutes(50),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenObject);
            return accessToken;
        }

        private async Task<string> PasswordHashAsync(string password)
        {
            string secretKey = "RickAndMortySecretKey";
            string combinedPassword = password + secretKey;

            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            string hashedPassword = stringBuilder.ToString();
            return hashedPassword;
        }

    }
}
