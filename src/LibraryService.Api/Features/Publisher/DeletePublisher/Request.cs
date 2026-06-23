using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.DeletePublisher;
/// <summary>
/// Represents the DeletePublisherCommand request.
/// </summary>
public sealed record DeletePublisherCommand(Guid Id) : IRequest<Result<Unit>>;