using FluentValidation;

namespace WebApi;

public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
{
    public GetGenreDetailQueryValidator()
    {
        RuleFor(q => q.GenreId).NotEmpty().GreaterThan(0);
    }
}