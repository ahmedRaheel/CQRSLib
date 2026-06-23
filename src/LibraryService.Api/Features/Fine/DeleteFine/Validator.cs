using FluentValidation;

namespace LibraryService.Api.Features.Fine.DeleteFine;
public sealed class DeleteFineCommandValidator : AbstractValidator<DeleteFineCommand>
{
    public DeleteFineCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}