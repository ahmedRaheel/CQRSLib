using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.GetMembersPaged;
/// <summary>
/// Represents the GetMembersPagedQuery request.
/// </summary>
public sealed record GetMembersPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<MemberDto>>>;