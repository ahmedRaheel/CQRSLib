using FluentValidation;

namespace LibraryService.Api.Features.Author.CreateAuthor;
public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}