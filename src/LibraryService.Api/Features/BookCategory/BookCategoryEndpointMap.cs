using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.BookCategory.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.BookCategory.CreateBookCategory;
using LibraryService.Api.Features.BookCategory.UpdateBookCategory;
using LibraryService.Api.Features.BookCategory.DeleteBookCategory;
using LibraryService.Api.Features.BookCategory.GetBookCategoryById;
using LibraryService.Api.Features.BookCategory.GetBookCategoriesPaged;

namespace LibraryService.Api.Features.BookCategory;
internal static class BookCategoryEndpointConstants
{
    public const string BaseRoute = "/api/v1/bookcategories";
    public const string Tag = "BookCategories";
    public const string CreateRouteName = "CreateBookCategory";
    public const string UpdateRouteName = "UpdateBookCategory";
    public const string DeleteRouteName = "DeleteBookCategory";
    public const string GetByIdRouteName = "GetBookCategoryById";
    public const string GetPagedRouteName = "GetBookCategoryPaged";
}

public static class BookCategoryEndpointMap
{
    public static IEndpointRouteBuilder MapBookCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BookCategoryEndpointConstants.BaseRoute).WithTags(BookCategoryEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(BookCategoryEndpointConstants.CreateRouteName).Produces<BookCategoryDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(BookCategoryEndpointConstants.UpdateRouteName).Produces<BookCategoryDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(BookCategoryEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(BookCategoryEndpointConstants.GetByIdRouteName).Produces<BookCategoryDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(BookCategoryEndpointConstants.GetPagedRouteName).Produces<PagedResult<BookCategoryDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateBookCategoryRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateBookCategoryCommand(request.BookId, request.CategoryId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(BookCategoryEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateBookCategoryRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateBookCategoryCommand(id, request.BookId, request.CategoryId);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteBookCategoryCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookCategoryByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetBookCategoriesPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}