namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat BookCategory data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record BookCategoryDto(Guid Id, Guid BookId, Guid CategoryId);