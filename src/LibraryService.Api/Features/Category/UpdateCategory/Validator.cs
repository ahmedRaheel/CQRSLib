using FluentValidation;

namespace LibraryService.Api.Features.Category.UpdateCategory;
public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}