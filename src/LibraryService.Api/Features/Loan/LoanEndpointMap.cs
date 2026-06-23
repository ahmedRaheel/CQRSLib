using LibraryService.Api.Extensions;
using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Dtos.Loan.Request;
using LibraryService.Api.Domain.Shared;
using LibraryService.Api.Features.Loan.CreateLoan;
using LibraryService.Api.Features.Loan.UpdateLoan;
using LibraryService.Api.Features.Loan.DeleteLoan;
using LibraryService.Api.Features.Loan.GetLoanById;
using LibraryService.Api.Features.Loan.GetLoansPaged;

namespace LibraryService.Api.Features.Loan;
internal static class LoanEndpointConstants
{
    public const string BaseRoute = "/api/v1/loans";
    public const string Tag = "Loans";
    public const string CreateRouteName = "CreateLoan";
    public const string UpdateRouteName = "UpdateLoan";
    public const string DeleteRouteName = "DeleteLoan";
    public const string GetByIdRouteName = "GetLoanById";
    public const string GetPagedRouteName = "GetLoanPaged";
}

public static class LoanEndpointMap
{
    public static IEndpointRouteBuilder MapLoanEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(LoanEndpointConstants.BaseRoute).WithTags(LoanEndpointConstants.Tag).WithOpenApi();
        group.MapPost("/", CreateAsync).WithName(LoanEndpointConstants.CreateRouteName).Produces<LoanDto>(StatusCodes.Status201Created).ProducesValidationProblem();
        group.MapPut("/{id:guid}", UpdateAsync).WithName(LoanEndpointConstants.UpdateRouteName).Produces<LoanDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).ProducesValidationProblem();
        group.MapDelete("/{id:guid}", DeleteAsync).WithName(LoanEndpointConstants.DeleteRouteName).Produces(StatusCodes.Status204NoContent).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/{id:guid}", GetByIdAsync).WithName(LoanEndpointConstants.GetByIdRouteName).Produces<LoanDto>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound);
        group.MapGet("/paged", GetPagedAsync).WithName(LoanEndpointConstants.GetPagedRouteName).Produces<PagedResult<LoanDto>>(StatusCodes.Status200OK);
        return app;
    }

    private static async Task<IResult> CreateAsync(CreateLoanRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new CreateLoanCommand(request.BookId, request.MemberId, request.LoanDate, request.DueDate);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToCreatedResult(LoanEndpointConstants.GetByIdRouteName, new { id = result.Value?.Id });
    }

    private static async Task<IResult> UpdateAsync(Guid id, UpdateLoanRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UpdateLoanCommand(id, request.BookId, request.MemberId, request.LoanDate, request.DueDate);
        var result = await sender.Send(command, cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> DeleteAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteLoanCommand(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetByIdAsync(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetLoanByIdQuery(id), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }

    private static async Task<IResult> GetPagedAsync(int pageNumber, int pageSize, string? search, ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetLoansPagedQuery(pageNumber, pageSize, search), cancellationToken).ConfigureAwait(false);
        return result.ToHttpResult();
    }
}