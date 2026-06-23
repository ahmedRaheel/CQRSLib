namespace LibraryService.Api.Domain.Dtos.Book.Request;
public sealed record CreateBookRequest(string Isbn, string Title);