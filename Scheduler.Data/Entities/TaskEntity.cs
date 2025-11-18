using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Scheduler.Data.Models;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

namespace Scheduler.Data.Entities;

[Table("tasks")]
public class TaskEntity
{
	[Column("id")]
	public Guid Id { get; set; }
	
	[Column("user_id")]
	public Guid UserId { get; set; }
	
	[Column("name")]
	[MaxLength(64)]
	public string Name { get; set; } = null!;
	
	[Column("description")]
	[MaxLength(256)]
	public string? Description { get; set; }
	
	[Column("start_at")]
	public DateTimeOffset StartAt { get; set; }
	
	[Column("duration")]
	public TimeSpan Duration { get; set; }
	
	[Column("status")]
	public TaskStatus Status { get; set; }
	
	[Column("priority")]
	public TaskPriority Priority { get; set; }
	
	// nav prop
	public UserEntity? User { get; set; }
}