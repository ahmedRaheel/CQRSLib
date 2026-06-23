using FluentValidation;

namespace LibraryService.Api.Features.Book.CreateBook;
public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Isbn).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}