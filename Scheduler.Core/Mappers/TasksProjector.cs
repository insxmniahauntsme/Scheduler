using Riok.Mapperly.Abstractions;
using Scheduler.Data.Entities;
using Task = Scheduler.Core.Models.Task;

namespace Scheduler.Core.Mappers;

[Mapper]
public static partial class TasksProjector
{
	[MapperIgnoreSource(nameof(TaskEntity.UserId))]
	public static partial List<Task> ToTasks(this List<TaskEntity> tasks);
}