using FluentValidation;

namespace LibraryService.Api.Features.BookPublisher.UpdateBookPublisher;
public sealed class UpdateBookPublisherCommandValidator : AbstractValidator<UpdateBookPublisherCommand>
{
    public UpdateBookPublisherCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.PublisherId).NotNull();
    }
}