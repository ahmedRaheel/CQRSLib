using FluentValidation;

namespace LibraryService.Api.Features.Publisher.CreatePublisher;
public sealed class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}