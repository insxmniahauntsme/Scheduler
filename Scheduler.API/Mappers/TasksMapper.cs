using Riok.Mapperly.Abstractions;
using Scheduler.Api.Models;
using Scheduler.Core.Models.Requests;
using Scheduler.Data.Entities;

namespace Scheduler.Api.Mappers;

[Mapper]
public static partial class TasksMapper
{
	public static partial AddTaskRequest ToRequest(this AddTaskModel model, Guid userId);
}