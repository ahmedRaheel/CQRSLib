using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.UpdateMember;
/// <summary>
/// Represents the UpdateMemberCommand request.
/// </summary>
public sealed record UpdateMemberCommand(Guid Id, string Name, string Email) : IRequest<Result<Unit>>;