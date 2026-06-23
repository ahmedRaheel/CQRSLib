using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.UpdateBook;
/// <summary>
/// Represents the UpdateBookCommand request.
/// </summary>
public sealed record UpdateBookCommand(Guid Id, string Isbn, string Title) : IRequest<Result<Unit>>;