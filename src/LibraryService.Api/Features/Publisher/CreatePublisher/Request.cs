using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.CreatePublisher;
/// <summary>
/// Represents the CreatePublisherCommand request.
/// </summary>
public sealed record CreatePublisherCommand(string Name) : IRequest<Result<PublisherDto>>;