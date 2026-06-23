using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.DeleteAuthor;
public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Domain.Shared.Result<Unit>>
{
    private readonly IAuthorCommandRepository _commands;
    private readonly IAuthorQueryRepository _query;
    public DeleteAuthorCommandHandler(IAuthorCommandRepository commands, IAuthorQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Domain.Shared.Result<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Author with ID {request.Id} was not found.");
        await _commands.DeleteWithChildrenAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Domain.Shared.Result<Unit>.Success(Unit.Value, "Author successfully deleted.");
    }
}