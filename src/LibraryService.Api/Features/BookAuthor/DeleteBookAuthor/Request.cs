using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.DeleteBookAuthor;
/// <summary>
/// Represents the DeleteBookAuthorCommand request.
/// </summary>
public sealed record DeleteBookAuthorCommand(Guid Id) : IRequest<Result<Unit>>;