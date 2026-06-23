namespace LibraryService.Api.Domain.Dtos.BookCategory.Request;
public sealed record UpdateBookCategoryRequest(Guid BookId, Guid CategoryId);