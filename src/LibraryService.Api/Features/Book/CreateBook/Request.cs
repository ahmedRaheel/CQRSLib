using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.CreateBook;
/// <summary>
/// Represents the CreateBookCommand request.
/// </summary>
public sealed record CreateBookCommand(string Isbn, string Title) : IRequest<Result<BookDto>>;