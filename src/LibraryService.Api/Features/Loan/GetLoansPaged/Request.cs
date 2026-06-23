using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.GetLoansPaged;
/// <summary>
/// Represents the GetLoansPagedQuery request.
/// </summary>
public sealed record GetLoansPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<LoanDto>>>;