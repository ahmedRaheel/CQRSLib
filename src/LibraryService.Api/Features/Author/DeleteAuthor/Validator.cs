using FluentValidation;

namespace LibraryService.Api.Features.Author.DeleteAuthor;
public sealed class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}