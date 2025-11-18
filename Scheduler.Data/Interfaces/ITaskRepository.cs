using Scheduler.Data.Entities;
namespace Scheduler.Data.Interfaces;

public interface ITaskRepository : IGenericRepository<TaskEntity>
{
	Task<List<TaskEntity>> FindByDate(Guid userId, DateOnly date);
}