using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.UpdateBookPublisher;
public sealed class UpdateBookPublisherCommandHandler : IRequestHandler<UpdateBookPublisherCommand, Result<Unit>>
{
    private readonly IBookPublisherCommandRepository _commands;
    private readonly IBookPublisherQueryRepository _query;
    public UpdateBookPublisherCommandHandler(IBookPublisherCommandRepository commands, IBookPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateBookPublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("BookPublisher with ID {request.Id} was not found.");
        entity.Update(request.BookId, request.PublisherId);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "BookPublisher successfully updated.");
    }
}