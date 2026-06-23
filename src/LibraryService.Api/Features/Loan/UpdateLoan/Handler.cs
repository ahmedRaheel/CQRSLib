using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.UpdateLoan;
public sealed class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Result<Unit>>
{
    private readonly ILoanCommandRepository _commands;
    private readonly ILoanQueryRepository _query;
    public UpdateLoanCommandHandler(ILoanCommandRepository commands, ILoanQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Loan with ID {request.Id} was not found.");
        entity.Update(request.BookId, request.MemberId, request.LoanDate, request.DueDate);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Loan successfully updated.");
    }
}