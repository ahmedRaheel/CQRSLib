using FluentValidation;

namespace LibraryService.Api.Features.BookCategory.UpdateBookCategory;
public sealed class UpdateBookCategoryCommandValidator : AbstractValidator<UpdateBookCategoryCommand>
{
    public UpdateBookCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.CategoryId).NotNull();
    }
}