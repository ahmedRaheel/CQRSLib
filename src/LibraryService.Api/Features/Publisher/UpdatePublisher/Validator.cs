using FluentValidation;

namespace LibraryService.Api.Features.Publisher.UpdatePublisher;
public sealed class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}