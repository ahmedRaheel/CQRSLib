using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.CreateFine;
public sealed class CreateFineCommandHandler : IRequestHandler<CreateFineCommand, Result<FineDto>>
{
    private readonly IFineCommandRepository _commands;
    private readonly IFineQueryRepository _query;
    public CreateFineCommandHandler(IFineCommandRepository commands, IFineQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<FineDto>> Handle(CreateFineCommand request, CancellationToken cancellationToken)
    {
        var entity = FineEntity.Create(request.LoanId, request.Amount);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new FineDto(entity.Id, entity.LoanId, entity.Amount);
        return Result<FineDto>.Success(response, "Fine successfully created.");
    }
}