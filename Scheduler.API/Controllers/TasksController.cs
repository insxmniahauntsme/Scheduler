using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.HttpContextExtensions;
using Scheduler.Api.Mappers;
using Scheduler.Api.Models;
using Scheduler.Core.Models.Requests;

namespace Scheduler.Api.Controllers;

[ApiController]
[Route("api/tasks")]
[Authorize]
public class TasksController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetTasks([FromQuery] DateOnly date)
	{
		var userId = HttpContext.GetUserId();

		var request = new FindTasksRequest(userId, date);

		var response = await mediator.Send(request);
		
		return Ok(new {response});
	}

	[HttpPost]
	public async Task<IActionResult> CreateTask(
		[FromBody] AddTaskModel model, 
		[FromServices] IValidator<AddTaskModel> validator)
	{
		await validator.ValidateAndThrowAsync(model);
		
		var userId = HttpContext.GetUserId();

		var request = model.ToRequest(userId);
		
		var response = await mediator.Send(request);
		
		return Ok(new {response});
	}
}