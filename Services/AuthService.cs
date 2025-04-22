using LoginApp.Data;
using LoginApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }
        public async Task<bool> RegisterUser(RegisterModel model)
        {
            var existingUser = await _userRepository.GetUserbyUsernameAsync(model.Email);
            if (existingUser != null) return false; // Username already taken

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password) // Hashing the password
            };

            await _userRepository.AddUserAsync(user);
            return true; // User successfully created

        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUserbyUsernameAsync(email);
            if (user == null )
            {
                return "User Not Found While Authenticate...";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, user.Email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
