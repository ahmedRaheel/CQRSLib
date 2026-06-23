namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat BookAuthor data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record BookAuthorDto(Guid Id, Guid BookId, Guid AuthorId);