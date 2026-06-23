using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.DeleteBookCategory;
/// <summary>
/// Represents the DeleteBookCategoryCommand request.
/// </summary>
public sealed record DeleteBookCategoryCommand(Guid Id) : IRequest<Result<Unit>>;