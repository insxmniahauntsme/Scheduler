using Scheduler.Data.Models;

namespace Scheduler.Api.Models;

public class AddTaskModel
{
	public string Name { get; set; } = null!;
	
	public string? Description { get; set; }
	
	public DateTimeOffset StartAt { get; set; }
	
	public TimeSpan Duration { get; set; }
	
	public TaskPriority Priority { get; set; }
}