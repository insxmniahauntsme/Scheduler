using FluentValidation;
using Scheduler.Api.Models;

namespace Scheduler.Api.Validators;

public class AddAccountModelValidator : AbstractValidator<AddAccountModel>
{
	public AddAccountModelValidator()
	{
		RuleFor(request => request.Email).EmailAddress();
		RuleFor(request => request.Password).NotNull().NotEmpty();
	}
}