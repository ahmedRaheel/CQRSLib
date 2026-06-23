using FluentValidation;

namespace LibraryService.Api.Features.BookPublisher.CreateBookPublisher;
public sealed class CreateBookPublisherCommandValidator : AbstractValidator<CreateBookPublisherCommand>
{
    public CreateBookPublisherCommandValidator()
    {
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.PublisherId).NotNull();
    }
}