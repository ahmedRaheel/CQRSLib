using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Fine.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Fine.CreateFine;
using LibraryService.Api.Features.Fine.UpdateFine;
using LibraryService.Api.Features.Fine.DeleteFine;
using LibraryService.Api.Features.Fine.GetFineById;
using LibraryService.Api.Features.Fine.GetFinesPaged;

namespace LibraryService.Api.Features.Fine;
internal static class FineEndpointConstants
{
    public const string BaseRoute = "/api/v1/fines";
    public const string Tag = "Fines";
    public const string CreateRouteName = "CreateFine";
    public const string UpdateRouteName = "UpdateFine";
    public const string DeleteRouteName = "DeleteFine";
    public const string GetByIdRouteName = "GetFineById";
    public const string GetPagedRouteName = "GetFinePaged";
}

public static class FineEndpointMap
{
    public static IEndpointRouteBuilder MapFineEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(FineEndpointConstants.BaseRoute).WithTags(FineEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(FineEndpointConstants.CreateRouteName).Produces<FineDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(FineEndpointConstants.UpdateRouteName).Produces<FineDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(FineEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(FineEndpointConstants.GetByIdRouteName).Produces<FineDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(FineEndpointConstants.GetPagedRouteName).Produces<PagedResult<FineDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateFineRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateFineCommand(request.LoanId, request.Amount);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(FineEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateFineRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateFineCommand(id, request.LoanId, request.Amount);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFineCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFineByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFinesPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}