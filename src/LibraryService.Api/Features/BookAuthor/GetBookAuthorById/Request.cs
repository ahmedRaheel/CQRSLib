using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookAuthor.GetBookAuthorById;
/// <summary>
/// Represents the GetBookAuthorByIdQuery request.
/// </summary>
public sealed record GetBookAuthorByIdQuery(Guid Id) : IRequest<Result<BookAuthorDto?>>;