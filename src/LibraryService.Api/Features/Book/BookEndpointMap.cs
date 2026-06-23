
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Book.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Extensions;
using LibraryService.Api.Features.Book.CreateBook;
using LibraryService.Api.Features.Book.DeleteBook;
using LibraryService.Api.Features.Book.GetBookById;
using LibraryService.Api.Features.Book.GetBooksPaged;
using LibraryService.Api.Features.Book.UpdateBook;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Features.Book;
internal static class BookEndpointConstants
{
    public const string BaseRoute = "/api/v1/books";
    public const string Tag = "Books";
    public const string CreateRouteName = "CreateBook";
    public const string UpdateRouteName = "UpdateBook";
    public const string DeleteRouteName = "DeleteBook";
    public const string GetByIdRouteName = "GetBookById";
    public const string GetPagedRouteName = "GetBookPaged";
}

public static class BookEndpointMap
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BookEndpointConstants.BaseRoute).WithTags(BookEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(BookEndpointConstants.CreateRouteName).Produces<BookDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(BookEndpointConstants.UpdateRouteName).Produces<BookDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(BookEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(BookEndpointConstants.GetByIdRouteName).Produces<BookDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(BookEndpointConstants.GetPagedRouteName).Produces<PagedResult<BookDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateBookRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateBookCommand(request.Isbn, request.Title);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(BookEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateBookRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateBookCommand(id, request.Isbn, request.Title);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteBookCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id,FastCqrs.IDispatcher sender, CancellationToken cancellationToken)
    {
        var result  = await sender.Send(new GetBookByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return  Results.Ok(result);
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBooksPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}