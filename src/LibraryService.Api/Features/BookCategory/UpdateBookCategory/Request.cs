using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.UpdateBookCategory;
/// <summary>
/// Represents the UpdateBookCategoryCommand request.
/// </summary>
public sealed record UpdateBookCategoryCommand(Guid Id, Guid BookId, Guid CategoryId) : IRequest<Result<Unit>>;