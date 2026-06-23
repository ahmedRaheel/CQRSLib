using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookAuthor.UpdateBookAuthor;
/// <summary>
/// Represents the UpdateBookAuthorCommand request.
/// </summary>
public sealed record UpdateBookAuthorCommand(Guid Id, Guid BookId, Guid AuthorId) : IRequest<Result<Unit>>;