# TaskFlow ASP.NET Core Work Plan

This solution implements the provided practical and laboratory works as one cross-cutting project. The detailed stage-by-stage handoff is in `docs/STAGE_GUIDE.md`, `submissions/`, and in the web UI at `/Works`.

| Work | Covered by |
| --- | --- |
| Practical 9 | EF Core entities, DbContext, SQL Server provider option, CRUD repositories for tasks and projects |
| Practical 10 | initial and model-change EF Core migrations, `Database.Migrate()`, DbContext lifetime through scoped DI |
| Lab 10 | three-plus related entities, repository/service, LINQ Include/report query |
| Practical 11 | Web API controller, JSON endpoints, DI service |
| Lab 11 | DTOs, status codes, Swagger UI and OpenAPI |
| Practical 12 | API backed by EF Core, request timing middleware |
| Lab 12 | layered architecture: Domain, Application, Infrastructure, Web; AutoMapper profile and usage |
| Practical 13 | exception middleware and controller logging filter |
| Lab 13 | Razor Pages UI for list/details/create |
| Practical 14 | routing, query binding, DataAnnotations validation |
| Lab 14 / Practical 16 | service logging and IMemoryCache with invalidation |
| Practical 17 | role and policy authorization with demo headers |

Run:

```powershell
dotnet run --no-build --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Key pages:

- `/Works` - map of all practical/laboratory works.
- `/Tasks` - Razor Pages UI.
- `/api/tasks` - JSON API.
- `/swagger` - Swagger UI.
- `/openapi/v1.json` - OpenAPI document.

Demo auth headers:

```http
X-Demo-User: ivan@example.com
X-Demo-Role: Admin
X-Demo-Department: ProjectOffice
```
