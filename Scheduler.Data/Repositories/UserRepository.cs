using Microsoft.EntityFrameworkCore;
using Scheduler.Data.Entities;
using Scheduler.Data.Interfaces;

namespace Scheduler.Data.Repositories;

public class UserRepository(SchedulerDbContext context) : GenericRepository<UserEntity>(context), IUserRepository
{
	public async Task<UserEntity?> GetByEmailAsync(string email)
	{
		return await Context.Users
			.FirstOrDefaultAsync(u => u.Email == email);
	}
}