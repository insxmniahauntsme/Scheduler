using MediatR;

namespace Scheduler.Core.Models.Requests;

public sealed record FindTasksRequest(Guid UserId, DateOnly Date) : IRequest<List<Task>>;