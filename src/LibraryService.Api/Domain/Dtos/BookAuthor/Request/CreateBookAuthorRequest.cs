namespace LibraryService.Api.Domain.Dtos.BookAuthor.Request;
public sealed record CreateBookAuthorRequest(Guid BookId, Guid AuthorId);