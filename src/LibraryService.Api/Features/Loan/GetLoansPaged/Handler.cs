using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.GetLoansPaged;
public sealed class GetLoansPagedQueryHandler : IRequestHandler<GetLoansPagedQuery, Result<PagedResult<LoanDto>>>
{
    private readonly ILoanQueryRepository _query;
    public GetLoansPagedQueryHandler(ILoanQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<LoanDto>>> Handle(GetLoansPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<LoanDto>>.Success(value, "Loan retrieved successfully.");
    }
}