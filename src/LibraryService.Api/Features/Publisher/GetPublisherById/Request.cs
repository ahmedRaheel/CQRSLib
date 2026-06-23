using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.GetPublisherById;
/// <summary>
/// Represents the GetPublisherByIdQuery request.
/// </summary>
public sealed record GetPublisherByIdQuery(Guid Id) : IRequest<Result<PublisherDto?>>;