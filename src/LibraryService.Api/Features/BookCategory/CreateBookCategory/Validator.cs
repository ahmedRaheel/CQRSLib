using FluentValidation;

namespace LibraryService.Api.Features.BookCategory.CreateBookCategory;
public sealed class CreateBookCategoryCommandValidator : AbstractValidator<CreateBookCategoryCommand>
{
    public CreateBookCategoryCommandValidator()
    {
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.CategoryId).NotNull();
    }
}