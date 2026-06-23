using FluentValidation;

namespace LibraryService.Api.Features.BookPublisher.DeleteBookPublisher;
public sealed class DeleteBookPublisherCommandValidator : AbstractValidator<DeleteBookPublisherCommand>
{
    public DeleteBookPublisherCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}