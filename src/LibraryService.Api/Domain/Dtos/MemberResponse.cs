namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Member data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record MemberDto(Guid Id, string Name, string Email);