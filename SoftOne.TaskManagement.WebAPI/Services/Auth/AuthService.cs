using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoftOne.TaskManagement.WebAPI.Context;
using SoftOne.TaskManagement.WebAPI.Entities._Dtos.Auth;
using SoftOne.TaskManagement.WebAPI.Entities.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftOne.TaskManagement.WebAPI.Services.Auth
{
    public class AuthService(AppDbContext context, IConfiguration configuration) : IAuthService
    {
        public async Task<User?> RegisterAsync(UserRegisterDto request)
        {
            if (await context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return null;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.NIC = request.NIC;
            user.Role = request.Role;
            user.PasswordHash = hashedPassword;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<string?> LogingAsync(UserLoginDto request)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user is null)
            { 
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claim = new List<Claim> {
                new Claim (ClaimTypes.Name, user.Email),
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescripiter = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claim,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescripiter);
        }
    }
}
