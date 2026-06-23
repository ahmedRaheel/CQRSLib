using FluentValidation;

namespace LibraryService.Api.Features.Publisher.DeletePublisher;
public sealed class DeletePublisherCommandValidator : AbstractValidator<DeletePublisherCommand>
{
    public DeletePublisherCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}