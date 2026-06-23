namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Category data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record CategoryDto(Guid Id, string Name);