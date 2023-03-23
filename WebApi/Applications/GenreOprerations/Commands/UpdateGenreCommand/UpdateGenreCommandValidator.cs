using FluentValidation;

namespace WebApi;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Name).MinimumLength(4).When(
            x => x.Model.Name != string.Empty
        );
        RuleFor(command => command.GenreId).NotNull().GreaterThan(0);
    }
}