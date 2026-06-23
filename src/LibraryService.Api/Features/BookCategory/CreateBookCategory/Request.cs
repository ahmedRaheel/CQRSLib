using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.CreateBookCategory;
/// <summary>
/// Represents the CreateBookCategoryCommand request.
/// </summary>
public sealed record CreateBookCategoryCommand(Guid BookId, Guid CategoryId) : IRequest<Result<BookCategoryDto>>;