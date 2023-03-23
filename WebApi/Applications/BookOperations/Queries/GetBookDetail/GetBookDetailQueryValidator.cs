using FluentValidation;

namespace WebApi;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(
            commamd => commamd.BookId
        ).NotEmpty().GreaterThan(0);
    }
}