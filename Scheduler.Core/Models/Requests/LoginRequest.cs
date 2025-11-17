using MediatR;

namespace Scheduler.Core.Models.Requests;

public sealed record LoginRequest(string Email, string Password) : IRequest<string>;