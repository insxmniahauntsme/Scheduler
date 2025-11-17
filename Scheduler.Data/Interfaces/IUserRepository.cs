using Scheduler.Data.Entities;

namespace Scheduler.Data.Interfaces;

public interface IUserRepository : IGenericRepository<UserEntity>
{
	Task<UserEntity?> GetByEmailAsync(string email);
}