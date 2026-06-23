using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Book.GetBookById;
/// <summary>
/// Represents the GetBookByIdQuery request.
/// </summary>
public sealed record GetBookByIdQuery(Guid Id) : IRequest<Domain.Shared.Result<BookDto?>>;