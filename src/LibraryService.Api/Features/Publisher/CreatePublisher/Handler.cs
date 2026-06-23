using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.CreatePublisher;
public sealed class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, Result<PublisherDto>>
{
    private readonly IPublisherCommandRepository _commands;
    private readonly IPublisherQueryRepository _query;
    public CreatePublisherCommandHandler(IPublisherCommandRepository commands, IPublisherQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<PublisherDto>> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = PublisherEntity.Create(request.Name);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new PublisherDto(entity.Id, entity.Name);
        return Result<PublisherDto>.Success(response, "Publisher successfully created.");
    }
}