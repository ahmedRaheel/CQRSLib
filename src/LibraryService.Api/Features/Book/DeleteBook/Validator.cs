using FluentValidation;

namespace LibraryService.Api.Features.Book.DeleteBook;
public sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}