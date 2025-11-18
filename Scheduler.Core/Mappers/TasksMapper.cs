using Riok.Mapperly.Abstractions;
using Scheduler.Core.Models.Requests;
using Scheduler.Data.Entities;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

namespace Scheduler.Core.Mappers;

[Mapper]
public static partial class TasksMapper
{
	[MapperIgnoreTarget(nameof(TaskEntity.Id))]
	[MapperIgnoreTarget(nameof(TaskEntity.User))]
	[MapValue(nameof(TaskEntity.Status), TaskStatus.Planned)]
	public static partial TaskEntity ToEntity(this AddTaskRequest request);
}