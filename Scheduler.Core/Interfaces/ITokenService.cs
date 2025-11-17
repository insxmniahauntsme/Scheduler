using Scheduler.Data.Entities;

namespace Scheduler.Core.Interfaces;

public interface ITokenService
{
	string GenerateToken(Guid userId, string email);
}