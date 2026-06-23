using LibraryService.Api.Extensions;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.BookAuthor.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.BookAuthor.CreateBookAuthor;
using LibraryService.Api.Features.BookAuthor.UpdateBookAuthor;
using LibraryService.Api.Features.BookAuthor.DeleteBookAuthor;
using LibraryService.Api.Features.BookAuthor.GetBookAuthorById;
using LibraryService.Api.Features.BookAuthor.GetBookAuthorsPaged;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor;
internal static class BookAuthorEndpointConstants
{
    public const string BaseRoute = "/api/v1/bookauthors";
    public const string Tag = "BookAuthors";
    public const string CreateRouteName = "CreateBookAuthor";
    public const string UpdateRouteName = "UpdateBookAuthor";
    public const string DeleteRouteName = "DeleteBookAuthor";
    public const string GetByIdRouteName = "GetBookAuthorById";
    public const string GetPagedRouteName = "GetBookAuthorPaged";
}

public static class BookAuthorEndpointMap
{
    public static IEndpointRouteBuilder MapBookAuthorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BookAuthorEndpointConstants.BaseRoute).WithTags(BookAuthorEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(BookAuthorEndpointConstants.CreateRouteName).Produces<BookAuthorDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(BookAuthorEndpointConstants.UpdateRouteName).Produces<BookAuthorDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(BookAuthorEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(BookAuthorEndpointConstants.GetByIdRouteName).Produces<BookAuthorDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(BookAuthorEndpointConstants.GetPagedRouteName).Produces<PagedResult<BookAuthorDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateBookAuthorRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateBookAuthorCommand(request.BookId, request.AuthorId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(BookAuthorEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateBookAuthorRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateBookAuthorCommand(id, request.BookId, request.AuthorId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteBookAuthorCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookAuthorByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookAuthorsPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}