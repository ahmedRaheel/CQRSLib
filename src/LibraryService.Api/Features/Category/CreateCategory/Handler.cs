using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.CreateCategory;
public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
{
    private readonly ICategoryCommandRepository _commands;
    private readonly ICategoryQueryRepository _query;
    public CreateCategoryCommandHandler(ICategoryCommandRepository commands, ICategoryQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = CategoryEntity.Create(request.Name);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new CategoryDto(entity.Id, entity.Name);
        return Result<CategoryDto>.Success(response, "Category successfully created.");
    }
}