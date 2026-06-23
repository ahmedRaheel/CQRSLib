namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Publisher data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record PublisherDto(Guid Id, string Name);