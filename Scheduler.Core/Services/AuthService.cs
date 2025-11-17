using System.Security.Cryptography;
using System.Text;
using Scheduler.Core.Interfaces;
using Scheduler.Data.Entities;
using Scheduler.Data.Interfaces;

namespace Scheduler.Core.Services;

public class AuthService(IUserRepository userRepository, ITokenService tokenService) : IAuthService
{
    public string HashPassword(string password, string saltBase64)
    {
        var salt = Convert.FromBase64String(saltBase64);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            100_000,
            HashAlgorithmName.SHA256,
            32
        );

        return Convert.ToBase64String(hash);
    }

    public string GenerateSalt(string password)
    {
        var saltBytes = RandomNumberGenerator.GetBytes(16);
        return Convert.ToBase64String(saltBytes);
    }
}
