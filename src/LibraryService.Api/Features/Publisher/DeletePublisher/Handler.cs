using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.DeletePublisher;
public sealed class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, Result<Unit>>
{
    private readonly IPublisherCommandRepository _commands;
    private readonly IPublisherQueryRepository _query;
    public DeletePublisherCommandHandler(IPublisherCommandRepository commands, IPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Publisher with ID {request.Id} was not found.");
        await _commands.DeleteWithChildrenAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Publisher successfully deleted.");
    }
}