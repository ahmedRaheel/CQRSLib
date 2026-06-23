using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.UpdateCategory;
public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Unit>>
{
    private readonly ICategoryCommandRepository _commands;
    private readonly ICategoryQueryRepository _query;
    public UpdateCategoryCommandHandler(ICategoryCommandRepository commands, ICategoryQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Category with ID {request.Id} was not found.");
        entity.Update(request.Name);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Category successfully updated.");
    }
}