using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.DeleteBook;
/// <summary>
/// Represents the DeleteBookCommand request.
/// </summary>
public sealed record DeleteBookCommand(Guid Id) : IRequest<Result<Unit>>;