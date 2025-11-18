using MediatR;
using Scheduler.Core.Mappers;
using Scheduler.Core.Models.Requests;
using Scheduler.Data.Interfaces;

namespace Scheduler.Core.Handlers;

internal sealed class AddTaskHandler(ITaskRepository taskRepository) : IRequestHandler<AddTaskRequest, Guid>
{
	public async Task<Guid> Handle(AddTaskRequest request, CancellationToken cancellationToken)
	{
		var entity = request.ToEntity();

		entity.UserId = request.UserId;

		await taskRepository.AddAsync(entity);

		await taskRepository.SaveChangesAsync();
		
		return entity.Id;
	}
}