using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.GetBookCategoryById;
/// <summary>
/// Represents the GetBookCategoryByIdQuery request.
/// </summary>
public sealed record GetBookCategoryByIdQuery(Guid Id) : IRequest<Result<BookCategoryDto?>>;