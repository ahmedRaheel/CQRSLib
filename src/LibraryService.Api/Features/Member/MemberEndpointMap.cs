using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Member.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Member.CreateMember;
using LibraryService.Api.Features.Member.UpdateMember;
using LibraryService.Api.Features.Member.DeleteMember;
using LibraryService.Api.Features.Member.GetMemberById;
using LibraryService.Api.Features.Member.GetMembersPaged;

namespace LibraryService.Api.Features.Member;
internal static class MemberEndpointConstants
{
    public const string BaseRoute = "/api/v1/members";
    public const string Tag = "Members";
    public const string CreateRouteName = "CreateMember";
    public const string UpdateRouteName = "UpdateMember";
    public const string DeleteRouteName = "DeleteMember";
    public const string GetByIdRouteName = "GetMemberById";
    public const string GetPagedRouteName = "GetMemberPaged";
}

public static class MemberEndpointMap
{
    public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(MemberEndpointConstants.BaseRoute).WithTags(MemberEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(MemberEndpointConstants.CreateRouteName).Produces<MemberDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(MemberEndpointConstants.UpdateRouteName).Produces<MemberDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(MemberEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(MemberEndpointConstants.GetByIdRouteName).Produces<MemberDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(MemberEndpointConstants.GetPagedRouteName).Produces<PagedResult<MemberDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateMemberRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateMemberCommand(request.Name, request.Email);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(MemberEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateMemberRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateMemberCommand(id, request.Name, request.Email);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteMemberCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMemberByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMembersPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}