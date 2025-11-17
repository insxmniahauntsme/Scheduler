using Microsoft.EntityFrameworkCore;
using Scheduler.Data.Entities;
using Scheduler.Data.Interfaces;

namespace Scheduler.Data.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
	public UserRepository(SchedulerDbContext context)
		: base(context)
	{ }

	public async Task<UserEntity?> GetByEmailAsync(string email)
	{
		return await Context.Users
			.FirstOrDefaultAsync(u => u.Email == email);
	}
}