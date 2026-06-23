namespace LibraryService.Api.Domain.Dtos.BookCategory.Request;
public sealed record CreateBookCategoryRequest(Guid BookId, Guid CategoryId);