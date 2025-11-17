using FluentValidation;
using Scheduler.Api.Models;

namespace Scheduler.Api.Validators;

public class CreateAccountRequestValidator : AbstractValidator<CreateAccountModel>
{
	public CreateAccountRequestValidator()
	{
		RuleFor(request => request.Email).EmailAddress();
		RuleFor(request => request.Password).NotNull().NotEmpty();
	}
}