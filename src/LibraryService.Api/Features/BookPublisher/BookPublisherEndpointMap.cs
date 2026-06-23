using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.BookPublisher.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.BookPublisher.CreateBookPublisher;
using LibraryService.Api.Features.BookPublisher.UpdateBookPublisher;
using LibraryService.Api.Features.BookPublisher.DeleteBookPublisher;
using LibraryService.Api.Features.BookPublisher.GetBookPublisherById;
using LibraryService.Api.Features.BookPublisher.GetBookPublishersPaged;

namespace LibraryService.Api.Features.BookPublisher;
internal static class BookPublisherEndpointConstants
{
    public const string BaseRoute = "/api/v1/bookpublishers";
    public const string Tag = "BookPublishers";
    public const string CreateRouteName = "CreateBookPublisher";
    public const string UpdateRouteName = "UpdateBookPublisher";
    public const string DeleteRouteName = "DeleteBookPublisher";
    public const string GetByIdRouteName = "GetBookPublisherById";
    public const string GetPagedRouteName = "GetBookPublisherPaged";
}

public static class BookPublisherEndpointMap
{
    public static IEndpointRouteBuilder MapBookPublisherEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BookPublisherEndpointConstants.BaseRoute).WithTags(BookPublisherEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(BookPublisherEndpointConstants.CreateRouteName).Produces<BookPublisherDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(BookPublisherEndpointConstants.UpdateRouteName).Produces<BookPublisherDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(BookPublisherEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(BookPublisherEndpointConstants.GetByIdRouteName).Produces<BookPublisherDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(BookPublisherEndpointConstants.GetPagedRouteName).Produces<PagedResult<BookPublisherDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateBookPublisherRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateBookPublisherCommand(request.BookId, request.PublisherId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(BookPublisherEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateBookPublisherRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateBookPublisherCommand(id, request.BookId, request.PublisherId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteBookPublisherCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookPublisherByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookPublishersPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}