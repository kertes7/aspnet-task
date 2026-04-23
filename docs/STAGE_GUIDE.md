# TaskFlow Stage Guide

This file explains how to present each practical/laboratory work as a separate step of one cross-cutting ASP.NET Core project.

## Run

```powershell
cd C:\Users\Kertes\Documents\Codex\2026-04-22-files-mentioned-by-the-user-14
dotnet run --no-build --project src\TaskFlow.Web\TaskFlow.Web.csproj --urls http://localhost:5124
```

Open:

- UI: http://localhost:5124/Tasks
- Works map: http://localhost:5124/Works
- API JSON: http://localhost:5124/api/tasks
- Swagger UI: http://localhost:5124/swagger
- OpenAPI JSON: http://localhost:5124/openapi/v1.json

## Practical 9

Topic: Entity Framework Core and SQL.

Implemented:

- Domain entities: `AppUser`, `Project`, `WorkTask`, `TaskComment`.
- EF Core `TaskFlowDbContext`.
- SQLite local database connection and SQL Server connection option.
- CRUD repository/API for tasks.
- CRUD repository/API for projects as a second entity.

Show:

- `src/TaskFlow.Domain`
- `src/TaskFlow.Infrastructure/TaskFlowDbContext.cs`
- `src/TaskFlow.Infrastructure/Repositories/EfWorkTaskRepository.cs`
- `src/TaskFlow.Infrastructure/Repositories/EfProjectRepository.cs`
- `src/TaskFlow.Infrastructure/ServiceCollectionExtensions.cs`
- `GET /api/tasks`
- `GET /api/projects`

## Practical 10

Topic: migrations and DbContext lifecycle.

Implemented:

- EF Core migration `InitialCreate`.
- EF Core migration `AddProjectCodeAndProjectCrud`.
- Updated model with relations and status field.
- Model evolution: new `Project.Code` field with unique index.
- Scoped `DbContext` registration in DI.
- Short-lived DbContext usage per HTTP request.
- Update/delete flows with `SaveChangesAsync`.

Show:

- `src/TaskFlow.Infrastructure/ServiceCollectionExtensions.cs`
- `src/TaskFlow.Infrastructure/Migrations`
- `src/TaskFlow.Web/Program.cs`
- `PUT /api/tasks/{id}`
- `DELETE /api/tasks/{id}`
- `GET /api/projects`

## Laboratory 10

Topic: complete ORM application.

Implemented:

- More than three related entities.
- Repository/service data access module.
- LINQ filtering, ordering, `Include` and grouping report.

Show:

- `src/TaskFlow.Application/Services/WorkTaskService.cs`
- `GET /api/tasks?search=API`
- `GET /api/tasks/report/status`

## Practical 11

Topic: ASP.NET Core Web API, controllers, JSON, DI.

Implemented:

- `TasksController`.
- `ProjectsController`.
- JSON endpoints.
- Service injected through constructor DI.
- Proper HTTP responses.

Show:

- `src/TaskFlow.Web/Controllers/TasksController.cs`
- `src/TaskFlow.Web/Controllers/ProjectsController.cs`
- `GET /api/tasks`
- `GET /api/tasks/1`
- `POST /api/tasks`
- `GET /api/projects`

## Laboratory 11

Topic: full Web API application.

Implemented:

- DTO classes for create/update/response.
- CRUD endpoints.
- Status codes: `200`, `201`, `400`, `404`.
- Swagger UI and OpenAPI document.

Show:

- `src/TaskFlow.Application/Dtos/WorkTaskDtos.cs`
- `src/TaskFlow.Web/Controllers/TasksController.cs`
- `GET /swagger`
- `GET /openapi/v1.json`

## Practical 12

Topic: EF Core in API and middleware pipeline.

Implemented:

- API reads/writes real DB data.
- Custom request timing middleware.
- Middleware connected in pipeline.

Show:

- `src/TaskFlow.Web/Middleware/RequestTimingMiddleware.cs`
- console logs while opening `/api/tasks`

## Laboratory 12

Topic: layered architecture.

Implemented:

- `Domain`, `Application`, `Infrastructure`, `Web` projects.
- Controllers call the application service.
- Repository hides `DbContext`.
- AutoMapper profile is included and used for DTO mapping.

Show:

- solution structure
- `src/TaskFlow.Application/Mapping/WorkTaskProfile.cs`
- `src/TaskFlow.Application/Services/WorkTaskService.cs`

## Practical 13

Topic: exception handling middleware and filters.

Implemented:

- Central exception middleware returns JSON errors.
- Controller logging filter logs action start/end.
- Error demo endpoint.

Show:

- `src/TaskFlow.Web/Middleware/ExceptionHandlingMiddleware.cs`
- `src/TaskFlow.Web/Filters/ControllerLoggingFilter.cs`
- `GET /api/tasks/error-demo`

## Laboratory 13

Topic: UI web application.

Implemented:

- Razor Pages UI.
- List, details, create, edit, delete.
- Server validation and service integration.

Show:

- `GET /Tasks`
- `GET /Tasks/Create`
- `GET /Tasks/Edit/1`
- `GET /Tasks/Delete/1`

## Practical 14

Topic: Swagger/OpenAPI, routing, model binding, validation.

Implemented:

- Route parameters: `/api/tasks/{id}`.
- Query binding: `/api/tasks?search=...`.
- Body binding for POST/PUT.
- DataAnnotations validation.
- Swagger UI and OpenAPI document.

Show:

- `src/TaskFlow.Application/Dtos/WorkTaskDtos.cs`
- `GET /swagger`
- `GET /openapi/v1.json`

## Laboratory 14

Topic: logging and caching.

Implemented:

- Service logs CRUD actions.
- `IMemoryCache` caches task list results.
- Cache invalidation after create/update/delete.

Show:

- `src/TaskFlow.Application/Services/WorkTaskService.cs`
- open `/api/tasks` twice and watch console logs for cache hit/miss.

## Practical 15

Topic: Razor Pages.

Implemented:

- Razor Pages app connected to EF-backed service.
- Create form uses binding and validation.
- Details/list pages display data.

Show:

- `src/TaskFlow.Web/Pages/Tasks`
- `GET /Tasks/Create`

## Practical 16

Topic: architecture, anti-patterns, logging, caching.

Implemented:

- Thin controller.
- Business logic in application service.
- Data access in repository.
- Logging/caching integrated in service layer.

Show:

- `TasksController`
- `WorkTaskService`
- `EfWorkTaskRepository`

## Practical 17

Topic: authentication and authorization with roles, claims and policies.

Implemented:

- Demo header authentication.
- Role-protected create/delete endpoints.
- Policy-protected claims demo endpoint.
- Correct `UseAuthentication()` before `UseAuthorization()`.

Show:

- `src/TaskFlow.Web/Auth/HeaderAuthenticationHandler.cs`
- `src/TaskFlow.Web/Program.cs`
- `GET /api/tasks/secure/claims-demo` with headers:

```http
X-Demo-User: ivan@example.com
X-Demo-Role: Admin
X-Demo-Department: ProjectOffice
```
