using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.CreateMember;
/// <summary>
/// Represents the CreateMemberCommand request.
/// </summary>
public sealed record CreateMemberCommand(string Name, string Email) : IRequest<Result<MemberDto>>;