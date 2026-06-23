using FluentValidation;

namespace LibraryService.Api.Features.BookAuthor.UpdateBookAuthor;
public sealed class UpdateBookAuthorCommandValidator : AbstractValidator<UpdateBookAuthorCommand>
{
    public UpdateBookAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.AuthorId).NotNull();
    }
}