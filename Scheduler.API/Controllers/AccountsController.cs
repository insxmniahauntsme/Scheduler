using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Api.Mappers;
using Scheduler.Api.Models;

namespace Scheduler.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController(IMediator mediator) : ControllerBase
{
	[HttpPost("create")]
	public async Task<IActionResult> CreateAccount(
		AddAccountModel model, 
		[FromServices] IValidator<AddAccountModel> validator)
	{
		await validator.ValidateAndThrowAsync(model);

		var request = model.ToRequest();
		
		var token = await mediator.Send(request);

		return Ok(new { token });
	}
	
	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginModel model)
	{
		var request = model.ToRequest();
		
		var token = await mediator.Send(request);

		return Ok(new { token });
	}
}