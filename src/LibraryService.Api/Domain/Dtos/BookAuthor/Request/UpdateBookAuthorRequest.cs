namespace LibraryService.Api.Domain.Dtos.BookAuthor.Request;
public sealed record UpdateBookAuthorRequest(Guid BookId, Guid AuthorId);