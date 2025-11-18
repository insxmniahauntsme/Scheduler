using Scheduler.Data.Entities;
using Scheduler.Data.Models;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

namespace Scheduler.Core.Models;

public class Task
{
	public Guid Id { get; set; }
	
	public string Name { get; set; } = null!;
	
	public string Description { get; set; } = null!;
	
	public DateTimeOffset StartAt { get; set; }
	
	public TimeSpan Duration { get; set; }
	
	public TaskStatus Status { get; set; }
	
	public TaskPriority Priority { get; set; }
	
	public UserEntity? User { get; set; }
}