using MediatR;
using Scheduler.Data.Models;

namespace Scheduler.Core.Models.Requests;

public sealed record AddTaskRequest : IRequest<Guid>
{
	public Guid UserId { get; set; }
	public string Name { get; set; } = null!;
	
	public string? Description { get; set; }
	
	public DateTimeOffset StartAt { get; set; }
	
	public TimeSpan Duration { get; set; }
	
	public TaskPriority Priority { get; set; }
}