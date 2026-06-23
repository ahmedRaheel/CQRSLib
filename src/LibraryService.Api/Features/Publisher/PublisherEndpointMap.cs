using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Publisher.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Publisher.CreatePublisher;
using LibraryService.Api.Features.Publisher.UpdatePublisher;
using LibraryService.Api.Features.Publisher.DeletePublisher;
using LibraryService.Api.Features.Publisher.GetPublisherById;
using LibraryService.Api.Features.Publisher.GetPublishersPaged;

namespace LibraryService.Api.Features.Publisher;
internal static class PublisherEndpointConstants
{
    public const string BaseRoute = "/api/v1/publishers";
    public const string Tag = "Publishers";
    public const string CreateRouteName = "CreatePublisher";
    public const string UpdateRouteName = "UpdatePublisher";
    public const string DeleteRouteName = "DeletePublisher";
    public const string GetByIdRouteName = "GetPublisherById";
    public const string GetPagedRouteName = "GetPublisherPaged";
}

public static class PublisherEndpointMap
{
    public static IEndpointRouteBuilder MapPublisherEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(PublisherEndpointConstants.BaseRoute).WithTags(PublisherEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(PublisherEndpointConstants.CreateRouteName).Produces<PublisherDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(PublisherEndpointConstants.UpdateRouteName).Produces<PublisherDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(PublisherEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(PublisherEndpointConstants.GetByIdRouteName).Produces<PublisherDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(PublisherEndpointConstants.GetPagedRouteName).Produces<PagedResult<PublisherDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreatePublisherRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreatePublisherCommand(request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(PublisherEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdatePublisherRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdatePublisherCommand(id, request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeletePublisherCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetPublisherByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetPublishersPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}