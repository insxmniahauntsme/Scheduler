using FluentValidation;
using Scheduler.Api.Models;

namespace Scheduler.Api.Validators;

public class AddTaskModelValidator : AbstractValidator<AddTaskModel>
{
	public AddTaskModelValidator()
	{
		RuleFor(x => x.Name).Length(1, 64);
		RuleFor(x => x.Description).Length(1, 256).When(x => x.Description is not null);
		RuleFor(x => x.StartAt).Must(x => x >= DateTime.Now)
			.WithMessage("You can only make plans on future.");
	}
}