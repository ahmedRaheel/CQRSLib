using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.UpdatePublisher;
/// <summary>
/// Represents the UpdatePublisherCommand request.
/// </summary>
public sealed record UpdatePublisherCommand(Guid Id, string Name) : IRequest<Result<Unit>>;