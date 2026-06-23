namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Author data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record AuthorDto(Guid Id, string Name);