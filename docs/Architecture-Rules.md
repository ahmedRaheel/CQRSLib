# Architecture rules

Architecture style: `VerticalSlice`

| Rule | Description | Source | Forbidden dependency |
|---|---|---|---|
| VSA001 | Domain folders must not depend on infrastructure folders | `LibraryService.Api.Domain` | `LibraryService.Api.Infrastructure` |
| VSA002 | Endpoints must not depend directly on repositories | `LibraryService.Api.Features` | `LibraryService.Api.Infrastructure.Data.Repositories` |