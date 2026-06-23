namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Book data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record BookDto(Guid Id, string Isbn, string Title);