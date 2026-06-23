using FluentValidation;

namespace LibraryService.Api.Features.Book.UpdateBook;
public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Isbn).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}