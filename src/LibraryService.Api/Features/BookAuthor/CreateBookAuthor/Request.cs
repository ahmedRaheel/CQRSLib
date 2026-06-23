using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.CreateBookAuthor;
/// <summary>
/// Represents the CreateBookAuthorCommand request.
/// </summary>
public sealed record CreateBookAuthorCommand(Guid BookId, Guid AuthorId) : IRequest<Result<BookAuthorDto>>;