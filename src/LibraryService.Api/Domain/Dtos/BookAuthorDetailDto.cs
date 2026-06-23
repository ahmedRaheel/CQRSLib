namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed BookAuthor DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record BookAuthorDetailDto(Guid Id, Guid BookId, Guid AuthorId, BookDto? Book, AuthorDto? Author);