using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.GetBookPublisherById;
/// <summary>
/// Represents the GetBookPublisherByIdQuery request.
/// </summary>
public sealed record GetBookPublisherByIdQuery(Guid Id) : IRequest<Result<BookPublisherDto?>>;