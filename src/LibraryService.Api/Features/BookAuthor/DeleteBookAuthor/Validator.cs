using FluentValidation;

namespace LibraryService.Api.Features.BookAuthor.DeleteBookAuthor;
public sealed class DeleteBookAuthorCommandValidator : AbstractValidator<DeleteBookAuthorCommand>
{
    public DeleteBookAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}