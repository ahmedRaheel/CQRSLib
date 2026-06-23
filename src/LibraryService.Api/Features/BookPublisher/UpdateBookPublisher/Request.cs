using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.UpdateBookPublisher;
/// <summary>
/// Represents the UpdateBookPublisherCommand request.
/// </summary>
public sealed record UpdateBookPublisherCommand(Guid Id, Guid BookId, Guid PublisherId) : IRequest<Result<Unit>>;