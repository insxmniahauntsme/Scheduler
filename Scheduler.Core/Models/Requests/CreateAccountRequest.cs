using MediatR;

namespace Scheduler.Core.Models.Requests;

public sealed record CreateAccountRequest(string Email, string Password) : IRequest<string>;