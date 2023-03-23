using FluentValidation;

namespace WebApi;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x => x.AuthorId).NotEmpty().GreaterThan(0);
    }
}