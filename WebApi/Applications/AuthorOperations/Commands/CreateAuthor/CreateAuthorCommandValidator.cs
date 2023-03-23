using FluentValidation;

namespace WebApi;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.Surname).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.Birthday.Date).LessThan(DateTime.Now.Date);
    }
}