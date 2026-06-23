using FluentValidation;

namespace LibraryService.Api.Features.BookAuthor.CreateBookAuthor;
public sealed class CreateBookAuthorCommandValidator : AbstractValidator<CreateBookAuthorCommand>
{
    public CreateBookAuthorCommandValidator()
    {
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.AuthorId).NotNull();
    }
}