using Scheduler.Core.Models;

namespace Scheduler.Core.Interfaces;

public interface IAuthService
{
	string HashPassword(string email, string saltBase64);
	string GenerateSalt(string password);
}