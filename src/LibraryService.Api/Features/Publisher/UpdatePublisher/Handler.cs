using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.UpdatePublisher;
public sealed class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, Result<Unit>>
{
    private readonly IPublisherCommandRepository _commands;
    private readonly IPublisherQueryRepository _query;
    public UpdatePublisherCommandHandler(IPublisherCommandRepository commands, IPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Publisher with ID {request.Id} was not found.");
        entity.Update(request.Name);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Publisher successfully updated.");
    }
}