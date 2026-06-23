using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Category.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Category.CreateCategory;
using LibraryService.Api.Features.Category.UpdateCategory;
using LibraryService.Api.Features.Category.DeleteCategory;
using LibraryService.Api.Features.Category.GetCategoryById;
using LibraryService.Api.Features.Category.GetCategoriesPaged;

namespace LibraryService.Api.Features.Category;
internal static class CategoryEndpointConstants
{
    public const string BaseRoute = "/api/v1/categories";
    public const string Tag = "Categories";
    public const string CreateRouteName = "CreateCategory";
    public const string UpdateRouteName = "UpdateCategory";
    public const string DeleteRouteName = "DeleteCategory";
    public const string GetByIdRouteName = "GetCategoryById";
    public const string GetPagedRouteName = "GetCategoryPaged";
}

public static class CategoryEndpointMap
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(CategoryEndpointConstants.BaseRoute).WithTags(CategoryEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(CategoryEndpointConstants.CreateRouteName).Produces<CategoryDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(CategoryEndpointConstants.UpdateRouteName).Produces<CategoryDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(CategoryEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(CategoryEndpointConstants.GetByIdRouteName).Produces<CategoryDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(CategoryEndpointConstants.GetPagedRouteName).Produces<PagedResult<CategoryDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateCategoryRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(CategoryEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateCategoryRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(id, request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCategoryCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCategoryByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCategoriesPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}