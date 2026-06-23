using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.DeleteMember;
/// <summary>
/// Represents the DeleteMemberCommand request.
/// </summary>
public sealed record DeleteMemberCommand(Guid Id) : IRequest<Result<Unit>>;