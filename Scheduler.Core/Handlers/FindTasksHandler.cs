using MediatR;
using Scheduler.Core.Mappers;
using Scheduler.Core.Models.Requests;
using Scheduler.Data.Interfaces;
using Task = Scheduler.Core.Models.Task;

namespace Scheduler.Core.Handlers;

internal sealed class FindTasksHandler(ITaskRepository taskRepository) : IRequestHandler<FindTasksRequest, List<Task>>
{
	public async Task<List<Task>> Handle(FindTasksRequest request, CancellationToken cancellationToken)
	{
		var entities = await taskRepository.FindByDate(request.UserId, request.Date);

		return entities.ToTasks();
	}
}