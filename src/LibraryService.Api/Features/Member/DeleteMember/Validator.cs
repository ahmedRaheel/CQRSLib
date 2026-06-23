using FluentValidation;

namespace LibraryService.Api.Features.Member.DeleteMember;
public sealed class DeleteMemberCommandValidator : AbstractValidator<DeleteMemberCommand>
{
    public DeleteMemberCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}