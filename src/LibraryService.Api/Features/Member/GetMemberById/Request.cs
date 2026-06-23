using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.GetMemberById;
/// <summary>
/// Represents the GetMemberByIdQuery request.
/// </summary>
public sealed record GetMemberByIdQuery(Guid Id) : IRequest<Result<MemberDto?>>;