using FluentValidation;

namespace LibraryService.Api.Features.BookCategory.DeleteBookCategory;
public sealed class DeleteBookCategoryCommandValidator : AbstractValidator<DeleteBookCategoryCommand>
{
    public DeleteBookCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}