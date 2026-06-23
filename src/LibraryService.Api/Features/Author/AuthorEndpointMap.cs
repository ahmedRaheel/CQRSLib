using LibraryService.Api.Extensions;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Author.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Author.CreateAuthor;
using LibraryService.Api.Features.Author.UpdateAuthor;
using LibraryService.Api.Features.Author.DeleteAuthor;
using LibraryService.Api.Features.Author.GetAuthorById;
using LibraryService.Api.Features.Author.GetAuthorsPaged;
using FastCqrs;

namespace LibraryService.Api.Features.Author;
internal static class AuthorEndpointConstants
{
    public const string BaseRoute = "/api/v1/authors";
    public const string Tag = "Authors";
    public const string CreateRouteName = "CreateAuthor";
    public const string UpdateRouteName = "UpdateAuthor";
    public const string DeleteRouteName = "DeleteAuthor";
    public const string GetByIdRouteName = "GetAuthorById";
    public const string GetPagedRouteName = "GetAuthorPaged";
}

public static class AuthorEndpointMap
{
    public static IEndpointRouteBuilder MapAuthorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(AuthorEndpointConstants.BaseRoute).WithTags(AuthorEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(AuthorEndpointConstants.CreateRouteName).Produces<AuthorDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(AuthorEndpointConstants.UpdateRouteName).Produces<AuthorDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(AuthorEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(AuthorEndpointConstants.GetByIdRouteName).Produces<AuthorDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(AuthorEndpointConstants.GetPagedRouteName).Produces<PagedResult<AuthorDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateAuthorRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateAuthorCommand(request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(AuthorEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateAuthorRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateAuthorCommand(id, request.Name);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteAuthorCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAuthorByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAuthorsPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}