using FluentValidation;

namespace LibraryService.Api.Features.Author.UpdateAuthor;
public sealed class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}