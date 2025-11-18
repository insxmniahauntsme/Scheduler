using Microsoft.EntityFrameworkCore;
using Scheduler.Data.Entities;
using Scheduler.Data.Interfaces;

namespace Scheduler.Data.Repositories;

public class TaskRepository(SchedulerDbContext context) : GenericRepository<TaskEntity>(context), ITaskRepository
{
	public async Task<List<TaskEntity>> FindByDate(Guid userId, DateOnly date)
	{
		return await Context.Tasks.Where(x => 
			DateOnly.FromDateTime(x.StartAt.Date) == date &&
			x.UserId == userId)
			.ToListAsync();
	}
}