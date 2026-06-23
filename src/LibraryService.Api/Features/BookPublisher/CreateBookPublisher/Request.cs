using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.CreateBookPublisher;
/// <summary>
/// Represents the CreateBookPublisherCommand request.
/// </summary>
public sealed record CreateBookPublisherCommand(Guid BookId, Guid PublisherId) : IRequest<Result<BookPublisherDto>>;