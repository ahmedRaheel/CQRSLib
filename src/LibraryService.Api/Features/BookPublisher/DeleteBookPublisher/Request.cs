using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.DeleteBookPublisher;
/// <summary>
/// Represents the DeleteBookPublisherCommand request.
/// </summary>
public sealed record DeleteBookPublisherCommand(Guid Id) : IRequest<Result<Unit>>;