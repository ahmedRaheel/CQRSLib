using FluentValidation;

namespace LibraryService.Api.Features.Category.DeleteCategory;
public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}